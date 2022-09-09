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
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Promovare_Angajat : Form
    {

        private List<JoinAngajatiiConcedii> listaAngajati = new List<JoinAngajatiiConcedii>();
        private List<AfisareAngajati> listaAngajati2 = new List<AfisareAngajati>();    


        public Promovare_Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<XD.Models.Echipa> NumeEchipa()
        {
            var url = "http://localhost:5107/Echipa/GetNume";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Echipa> listaNume = new List<XD.Models.Echipa>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                listaNume = JsonConvert.DeserializeObject<List<XD.Models.Echipa>>(result, settings);
            }
            return listaNume;

        }


        public List<XD.Models.Angajat> PromovareAngajati()
        {
            var url = "http://localhost:5107/api/PromovareAngajat/PromovareAngajat";
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



        public List<string> numeleEchipelor = new List<string>();
        private void Promovare_Angajat_Load(object sender, EventArgs e)
        {

            List<XD.Models.Angajat> lista = PromovareAngajati();

            foreach(var echipa in NumeEchipa())
            {
                numeleEchipelor.Add(echipa.Nume);
            }

            foreach (XD.Models.Angajat angajat in lista)
            {
                AfisareAngajati afisareAngajati = new AfisareAngajati();
                afisareAngajati.Nume = angajat.Nume;
                afisareAngajati.Prenume = angajat.Prenume;
                afisareAngajati.Email = angajat.Email;
                afisareAngajati.DataNasterii = angajat.DataNasterii;
                afisareAngajati.Numartelefon = angajat.Numartelefon;
                afisareAngajati.NumeEchipa = numeleEchipelor[(int)angajat.IdEchipa].ToString();
                listaAngajati2.Add(afisareAngajati);
            }

            dataGridView1.DataSource = listaAngajati2;

            dataGridView1.Columns["DataNasterii"].HeaderText = "Data Nasterii";
            dataGridView1.Columns["Numartelefon"].HeaderText = "Numarul de telefon";
            dataGridView1.Columns["NumeEchipa"].HeaderText = "Echipa";
            



            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Actiuni";
            buton.HeaderText = "Actiuni";
            buton.Text = "Promoveaza";
            buton.Tag = (Action<AfisareAngajati>)ClickHandler;
            buton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(buton);
            dataGridView1.CellContentClick += Buton_CellContentClick;

            for (int i = 0; i < listaAngajati2.Count; i++)
            {
                buton.FlatStyle = FlatStyle.Flat;
                var but1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[6]);
                but1.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.FromArgb(92, 183, 164);
                dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.FromArgb(9, 32, 30);

            }

            dataGridView1.EnableHeadersVisualStyles = false;
            //dataGridView1.Rows[0].HeaderCell.Style.BackColor = Color.Green;

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
                var clickHandler = (Action<AfisareAngajati>)grid.Columns[e.ColumnIndex].Tag;
                var person = (AfisareAngajati)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(person);
            }
        }
        private void ClickHandler(AfisareAngajati a)
        {
            Globals.EmailManager = a.Email;
            FormareEchipaAngajatPromovat form = new FormareEchipaAngajatPromovat();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)


        {






        }

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

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }

        int count = 1;
        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
