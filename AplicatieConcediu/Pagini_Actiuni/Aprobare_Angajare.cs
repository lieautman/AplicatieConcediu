using AplicatieConcediu.DB_Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Aprobare_Angajare : Form
    {
        private List<AngajatiListaPentruAngajare> AngajatiLista = new List<AngajatiListaPentruAngajare>();
        public Aprobare_Angajare()
        {
            InitializeComponent();
        }

        public List<XD.Models.Angajat> GetAprobareAngajare()
        {
            var url = "http://localhost:5107/AprobareAngajare/GetAprobareAngajare";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Angajat> list = new List<XD.Models.Angajat>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.Angajat>>(result, settings);
            }
            return list;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Adaugare_Angajat_Load(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select Nume, Prenume, Email, Parola,DataNasterii,CNP,SeriaNumarBuletin,Numartelefon from  Angajat WHERE EsteAngajatCuActeInRegula = 0", out conn);


            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                string parola = (string)reader["Parola"];
                DateTime datanasterii = (DateTime)reader["DataNasterii"];
                string Cnp = (string)reader["CNP"];
                string serianumarbuletin = (string)reader["SeriaNumarBuletin"];
                string numartelefon = (string)reader["Numartelefon"];

               


                AngajatiListaPentruAngajare angajati = new AngajatiListaPentruAngajare(nume, prenume, email, parola, datanasterii, Cnp, serianumarbuletin, numartelefon);

                AngajatiLista.Add(angajati);
            }
            reader.Close();*/

           

            //conn.Close();


            dataGridView1.DataSource = GetAprobareAngajare();


            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["DataAngajarii"].Visible = false;
            dataGridView1.Columns["DataNasterii"].HeaderText = "Data nasterii";
            dataGridView1.Columns["Cnp"].HeaderText = "CNP";
            dataGridView1.Columns["SeriaNumarBuletin"].HeaderText = "Seria si numarul de buletin";
            dataGridView1.Columns["Numartelefon"].HeaderText = "Nr. de telefon";
            dataGridView1.Columns["EsteAdmin"].Visible = false;
            dataGridView1.Columns["NumarZileConceiduRamase"].Visible = false;
            dataGridView1.Columns["ManagerId"].Visible = false;
            dataGridView1.Columns["EsteAngajatCuActeInRegula"].Visible = false;
            dataGridView1.Columns["idEchipa"].Visible = false;
            dataGridView1.Columns["Parola"].Visible = false;
            dataGridView1.Columns["Salariu"].Visible = false;



            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Aprobare Angajat";
            buton.HeaderText = "Aprobare Angajat";
            buton.Text = "Aproba";
            buton.Tag = (Action<XD.Models.Angajat>)ClickHandler;
            buton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(buton);
            dataGridView1.CellContentClick += Buton_CellContentClick;

            dataGridView1.ReadOnly = true;

        }

        private void Buton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
            {
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                var clickHandler = (Action<XD.Models.Angajat>)grid.Columns[e.ColumnIndex].Tag;
                var person = (XD.Models.Angajat)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(person);
            }
        }
        private void ClickHandler(XD.Models.Angajat a)
        {
            Globals.EmailAngajatCuActeNeinregula = a.Email;
            Form Angajare = new Adaugare_Date_Suplimetare_Angajat();
            this.Hide();
            Angajare.ShowDialog();
            this.Show();



        }

    }

}


