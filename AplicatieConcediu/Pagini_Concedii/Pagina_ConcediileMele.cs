using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;
using System.Text.Json;
using System.Net;
using AplicatieConcediu.DB_Classess;
using Newtonsoft.Json;

namespace AplicatieConcediu
{
    public partial class Pagina_ConcediileMele : Form
    {
        //lista concedii
        private List<XD.Models.Concediu> listaConcediu = new List<XD.Models.Concediu>();
        private List<AfisareConcedii> listaConcediiAfisate = new List<AfisareConcedii>();

        private List<Concediu> listaConcediuLegacy = new List<Concediu>();
        public Pagina_ConcediileMele()
        {
            InitializeComponent();
        }

        //calculare/aducere de zile concediu/zile ramase de concediu
        private int numarZileConceiduRamase = 0;
        //load legacy
        private void Pagina_ConcediileMele_LoadLegacy(object sender, EventArgs e)
        {
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }


            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select * from Concediu c join Angajat a on a.Id = c.AngajatId where a.Email = '"+ emailFolositLaSelect + "'", out conn);


            while (reader.Read())
            {
                int id = (int)reader["id"];
                int tipConcediuId = (int)reader["TipConcediuId"];
                DateTime dataInceput = (DateTime)reader["DataInceput"];
                DateTime dataSfarsit = (DateTime)reader["dataSfarsit"];
                int inlocuitorId = (int)reader["InlocuitorId"];
                string comentarii = (string)reader["Comentarii"];
                int stareConcediuId = (int)reader["StareConcediuId"];
                int angajatId = (int)reader["AngajatId"];

                Concediu concediu = new Concediu( id,  tipConcediuId,  dataInceput,  dataSfarsit,  inlocuitorId,  comentarii,  stareConcediuId,  angajatId);


                listaConcediuLegacy.Add(concediu);
            }
            reader.Close();

            dataGridView1.DataSource = listaConcediuLegacy;

            conn.Close();


            //incarcare label cu nr zile de concediu ramase
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Id, NumarZileConceiduRamase from Angajat where Email = '" + emailFolositLaSelect + "'", out conn1);

            while (reader1.Read())
            {
                Globals.IdUserActual1 = (int)reader1["Id"];
                numarZileConceiduRamase += (int)reader1["NumarZileConceiduRamase"];

            }
            reader1.Close();
            conn1.Close();
            label7.Text = numarZileConceiduRamase.ToString();


            label6.Text = (21 - numarZileConceiduRamase).ToString();
        }
        //load new
        private async void Pagina_ConcediileMele_Load(object sender, EventArgs e)
        {
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }

            //creare conexiune
            HttpClient httpClient = new HttpClient();

            XD.Models.Angajat a = new XD.Models.Angajat() { Email = emailFolositLaSelect, Parola="",Cnp="",Nume="",Prenume="",DataNasterii=new DateTime() };

            string jsonString = JsonConvert.SerializeObject(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:5107/Concediu/PostPreluareConcedii", stringContent);

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                listaConcediu = JsonConvert.DeserializeObject<List<XD.Models.Concediu>>(res);

                foreach (XD.Models.Concediu concediu in listaConcediu)
                {
                    AfisareConcedii ac = new AfisareConcedii();
                    ac.DataSfarsit = concediu.DataSfarsit;
                    ac.DataInceput = concediu.DataInceput;
                    ac.IdConcediu = concediu.Id.ToString();
                    ac.Comentarii = concediu.Comentarii;
                    ac.NumeInlocuitor = concediu.Inlocuitor.Nume;
                    ac.NumeTipConcediu = concediu.TipConcediu.Nume;
                    ac.NumeAngajat = concediu.Angajat.Nume;

                    listaConcediiAfisate.Add(ac);
                }

                dataGridView1.DataSource = listaConcediiAfisate;
            }

            //incarcare label cu nr zile de concediu ramase
            HttpClient httpClient1 = new HttpClient();
            string jsonString1 = JsonConvert.SerializeObject(a);
            StringContent stringContent1 = new StringContent(jsonString1, Encoding.UTF8, "application/json");
            var response1 = await httpClient1.PostAsync("http://localhost:5107/Angajat/PostPreluareNumarZileConcediuRamase", stringContent1);

            HttpContent content1 = response1.Content;
            Task<string> result1 = content1.ReadAsStringAsync();
            string res1 = result1.Result;

            XD.Models.Angajat ang1 = JsonConvert.DeserializeObject<XD.Models.Angajat>(res1);

            int numarZileConceiduRamase = 0;
            if (ang1.NumarZileConceiduRamase!=null)
                numarZileConceiduRamase = (int)ang1.NumarZileConceiduRamase;
            label7.Text = numarZileConceiduRamase.ToString();


            label6.Text = (21 - numarZileConceiduRamase).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
