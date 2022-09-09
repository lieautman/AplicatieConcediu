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
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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
            if (Globals.IsAdmin == true || Globals.IdManager == null)
            {
                button5.Show();
                button6.Show();
                button7.Show();
                button8.Show();

            }
            else
            {

                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();

            }

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
            dataGridView1.Columns["DataNasterii"].HeaderText = "Data nasterii"; //
            dataGridView1.Columns["Cnp"].HeaderText = "CNP"; //
            dataGridView1.Columns["SeriaNumarBuletin"].HeaderText = "Seria si nr. buletin"; //
            dataGridView1.Columns["Numartelefon"].HeaderText = "Numarul de telefon"; //
            dataGridView1.Columns["EsteAdmin"].Visible = false;
            dataGridView1.Columns["NumarZileConceiduRamase"].Visible = false;
            dataGridView1.Columns["ManagerId"].Visible = false;
            dataGridView1.Columns["EsteAngajatCuActeInRegula"].Visible = false;
            dataGridView1.Columns["idEchipa"].Visible = false;
            dataGridView1.Columns["Parola"].Visible = false;
            dataGridView1.Columns["Salariu"].Visible = false;
            dataGridView1.Columns["IdEchipaNavigation"].Visible = false;
            dataGridView1.Columns["Manager"].Visible = false;
            dataGridView1.Columns["ConcediuAngajats"].Visible = false;
            dataGridView1.Columns["InverseManager"].Visible = false;
            dataGridView1.Columns["ConcediuInlocuitors"].Visible = false;

            dataGridView1.Columns["SeriaNumarBuletin"].Width = 120;

           





            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Aprobare Angajat";
            buton.HeaderText = "Aprobare Angajat";
            buton.Text = "Aproba";
            buton.Tag = (Action<XD.Models.Angajat>)ClickHandlerAprobare;
            buton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(buton);
            dataGridView1.CellContentClick += Buton_CellContentClick;

            DataGridViewButtonColumn butonRespinge = new DataGridViewButtonColumn();
            butonRespinge.Name = "Respinge Angajat";
            butonRespinge.HeaderText = "Respingere Angajat";
            butonRespinge.Text = "Respinge ";
            butonRespinge.Tag = (Action<XD.Models.Angajat>)ClickHandlerRespingere;
            butonRespinge.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(butonRespinge);
            dataGridView1.CellContentClick += Buton_CellContentClick;
            dataGridView1.EnableHeadersVisualStyles = false;

            for (int i = 0; i < GetAprobareAngajare().Count; i++)
            {
                buton.FlatStyle = FlatStyle.Flat;
                var but1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[22]);
                but1.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[22].Style.BackColor = Color.FromArgb(249, 80, 0);
                dataGridView1.Rows[i].Cells[22].Style.ForeColor = Color.FromArgb(9, 32, 30);

                butonRespinge.FlatStyle = FlatStyle.Flat;
                var but2 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[23]);
                but2.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[23].Style.BackColor = Color.FromArgb(92, 183, 164);
                dataGridView1.Rows[i].Cells[23].Style.ForeColor = Color.FromArgb(9, 32, 30);
            }

            



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

      
        private void ClickHandlerAprobare(XD.Models.Angajat a)
        {

            Globals.EmailUserAprobare = a.Email;
            Form Angajare = new Adaugare_Date_Suplimetare_Angajat();
            this.Hide();
            Angajare.ShowDialog();
            this.Show();



        }

        // DELETE DIN BD

        private void ClickHandlerRespingere(XD.Models.Angajat a)
        {
            var url = String.Format("http://localhost:5107/Angajat/StergereAngajat/{0}", a.Email);
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "DELETE";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if(httpResponse.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Angajatul a fost respins");

            }
            else
            {
                MessageBox.Show("Eroare");
            }

            Aprobare_Angajare form = new Aprobare_Angajare();
            this.Hide();
            this.Close();
            form.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
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

        int count = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            count++;

            if (count % 2 != 0)
            {
                
                button3.Show();
                button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();
                button8.Show();
                button9.Show();
                button10.Show();
                button11.Show();

         

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

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
    }

}


