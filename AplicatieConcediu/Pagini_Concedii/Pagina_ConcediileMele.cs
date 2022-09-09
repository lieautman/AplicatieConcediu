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
using AplicatieConcediu.Pagini_Actiuni;

namespace AplicatieConcediu
{
    public partial class Pagina_ConcediileMele : Form
    {
        //lista concedii
        private List<XD.Models.Concediu> listaConcediu = new List<XD.Models.Concediu>();
        private List<AfisareConcedii> listaConcediiAfisate = new List<AfisareConcedii>();

        public Pagina_ConcediileMele()
        {
            InitializeComponent();
        }

        //calculare/aducere de zile concediu/zile ramase de concediu
        private int numarZileConceiduRamase = 0;

        //load new
        private async void Pagina_ConcediileMele_Load(object sender, EventArgs e)
        {
            if (Globals.IsAdmin == true || Globals.IdManager == null)
            {
                button7.Show();
                button8.Show();
                button9.Show();
                button10.Show();


            }
            else
            {

                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();

            }



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

                if(dataGridView1.DataSource != null)
            {
                dataGridView1.Columns["IdConcediu"].Visible = false;
                dataGridView1.Columns["NumeTipConcediu"].HeaderText = "Tipul concediului";
                dataGridView1.Columns["DataInceput"].HeaderText = "Data de inceput";
                dataGridView1.Columns["DataSfarsit"].HeaderText = "Data de sfarsit";
                dataGridView1.Columns["NumeInlocuitor"].HeaderText = "Inlocuitor";
                dataGridView1.Columns["Comentarii"].HeaderText = "Motiv";
                dataGridView1.Columns["NumeAngajat"].HeaderText = "Angajat";
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

        //buton inapoi
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form aprobareAngajat = new Aprobare_Angajare();
            this.Hide();
            aprobareAngajat.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }

        int count = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;

            if (count % 2 != 0)
            {
                button3.Show();
                button4.Show();
                button5.Show();
                button6.Show();
                button11.Show();

                if (Globals.IsAdmin == true || Globals.IdManager == null)
                {
                    button7.Show();
                    button8.Show();
                    button9.Show();
                    button10.Show();


                }

            }
            else
            {
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
            }
        }
    }
}
