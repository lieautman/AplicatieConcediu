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
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using AplicatieConcediu.Pagini_Profil;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using AplicatieConcediu.Pagini_Actiuni;
using System.Net.Http;
using Newtonsoft.Json;
using Azure;

namespace AplicatieConcediu
{
    public partial class TotiAngajatii : Form
    {


        private int numarDeAngajatiAfisati = 30;
        private int numarDePagini = 0;
        private int paginaActuala = 1;
        private List<ClasaJoinAngajatiConcediiTip> listaAngajati = new List<ClasaJoinAngajatiConcediiTip>();
        public TotiAngajatii()
        {
            InitializeComponent();

        }

        //deschide profilul uni angajat la click pe o celula din data grid view
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClasaJoinAngajatiConcediiTip a = listaAngajati[e.RowIndex];

                if (a.Email != Globals.EmailUserActual)
                    Globals.EmailUserViewed = a.Email;


                Form pagina_profil = new Pagina_Profil_Angajat();
                this.Hide();
                pagina_profil.ShowDialog();
                this.Show();
            }
        }

        //incarcare date angajati
        private async void TotiAngajatii_Load(object sender, EventArgs e)
        {

            if (Globals.IsAdmin == true || Globals.IdManager == null)
            {
                button4.Show();
                button5.Show();
                buttonPromovareAngajati.Show();
                button7.Show();
            }
            else
            {
                button4.Hide();
                button5.Hide();
                buttonPromovareAngajati.Hide();
                button7.Hide();
            }

            if (Globals.IdManager == null && Globals.IsAdmin == false)
                buttonPromovareAngajati.Hide();

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            HttpResponseMessage responseNrPagini;

            if (Globals.IdEchipa == 0)
            {
                response = await httpClient.GetAsync("http://localhost:5107/Angajat/GetPreluareDateDespreTotiAngajatii/0/" + numarDeAngajatiAfisati.ToString());
                responseNrPagini = await httpClient.GetAsync("http://localhost:5107/Angajat/GetPreluareNumarDePagini/0/" + numarDeAngajatiAfisati.ToString());
            }
            else
            {
                XD.Models.Angajat a = new XD.Models.Angajat();
                a.Cnp = "";
                a.Nume = "";
                a.Prenume = "";
                a.Email = "";
                a.IdEchipa = Globals.IdEchipa;

                string jsonString = JsonConvert.SerializeObject(a);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                StringContent stringContent2 = new StringContent(jsonString, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostPreluareDateDespreTotiAngajatiiDinEchipa/0/" + numarDeAngajatiAfisati.ToString(), stringContent);
                responseNrPagini = await httpClient.PostAsync("http://localhost:5107/Angajat/PostPreluareNumarDePaginiDinEchipa/0/" + numarDeAngajatiAfisati.ToString(), stringContent2);
            }

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            List<XD.Models.Angajat> listaConcedii = JsonConvert.DeserializeObject<List<XD.Models.Angajat>>(res);

            //daca am primit ceva
            if (listaConcedii != null)
            {
                foreach (XD.Models.Angajat ang in listaConcedii)
                {
                    string nume = ang.Nume;
                    string prenume = ang.Prenume;
                    string email = ang.Email;
                    string managerNumePrenume = "";
                    if (ang.Manager != null)
                    {
                        managerNumePrenume = ang.Manager.Nume + " " + ang.Manager.Prenume;
                    }
                    string numeEchipa = "";
                    if (ang.IdEchipaNavigation != null)
                    {
                        numeEchipa = ang.IdEchipaNavigation.Nume;
                    }

                    ClasaJoinAngajatiConcediiTip angajat = new ClasaJoinAngajatiConcediiTip(nume, prenume, email, managerNumePrenume, numeEchipa);

                    listaAngajati.Add(angajat);
                }
                dataGridView1.DataSource = listaAngajati;

                
                dataGridView1.Columns["ManagerNumePrenume"].HeaderText = "Manager";
                dataGridView1.Columns["NumeEchipa"].HeaderText = "Echipa";
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.AutoResizeColumns();
            }




            //gasire numar pagini si adaugare pe label

            HttpContent content2 = responseNrPagini.Content;
            Task<string> result2 = content2.ReadAsStringAsync();
            string res2 = result2.Result;
            int nrPagini = JsonConvert.DeserializeObject<int>(res2);

            labelPagina.Text = paginaActuala.ToString() + "/" + nrPagini.ToString();
        }

        //buton paginare inainte
        private async void buttonInainte_Click(object sender, EventArgs e)
        {
            if (paginaActuala + 1 <= numarDePagini)
            {
                dataGridView1.DataSource = null;
                paginaActuala++;
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response;
                HttpResponseMessage responseNrPagini;
                if (Globals.IdEchipa == 0)
                {
                    response = await httpClient.GetAsync("http://localhost:5107/Angajat/GetPreluareDateDespreTotiAngajatii/" + ((paginaActuala - 1) * numarDeAngajatiAfisati).ToString() + "/" + (paginaActuala * numarDeAngajatiAfisati).ToString());
                    responseNrPagini = await httpClient.GetAsync("http://localhost:5107/Angajat/GetPreluareNumarDePagini/" + ((paginaActuala - 1) * numarDeAngajatiAfisati).ToString() + "/" + (paginaActuala * numarDeAngajatiAfisati).ToString());
                }
                else
                {
                    XD.Models.Angajat a = new XD.Models.Angajat();
                    a.Cnp = "";
                    a.Nume = "";
                    a.Prenume = "";
                    a.Email = "";
                    a.IdEchipa = Globals.IdEchipa;

                    string jsonString = JsonConvert.SerializeObject(a);
                    StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    StringContent stringContent2 = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostPreluareDateDespreTotiAngajatiiDinEchipa/" + ((paginaActuala - 1) * numarDeAngajatiAfisati).ToString() + "/" + (paginaActuala * numarDeAngajatiAfisati).ToString(), stringContent);
                    responseNrPagini = await httpClient.PostAsync("http://localhost:5107/Angajat/PostPreluareNumarDePaginiDinEchipa/" + ((paginaActuala - 1) * numarDeAngajatiAfisati).ToString() + "/" + (paginaActuala * numarDeAngajatiAfisati).ToString(), stringContent2);
                }

                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                List<XD.Models.Angajat> listaConcedii = JsonConvert.DeserializeObject<List<XD.Models.Angajat>>(res);

                //daca am primit ceva
                if (listaConcedii != null)
                {
                    foreach (XD.Models.Angajat ang in listaConcedii)
                    {
                        string nume = ang.Nume;
                        string prenume = ang.Prenume;
                        string email = ang.Email;
                        string managerNumePrenume = "";
                        if (ang.Manager != null)
                        {
                            managerNumePrenume = ang.Manager.Nume + " " + ang.Manager.Prenume;
                        }
                        string numeEchipa = "";
                        if (ang.IdEchipaNavigation != null)
                        {
                            numeEchipa = ang.IdEchipaNavigation.Nume;
                        }

                        ClasaJoinAngajatiConcediiTip angajat = new ClasaJoinAngajatiConcediiTip(nume, prenume, email, managerNumePrenume, numeEchipa);

                        listaAngajati.Add(angajat);
                    }
                    dataGridView1.DataSource = listaAngajati;


                    dataGridView1.Columns["ManagerNumePrenume"].HeaderText = "Manager";
                    dataGridView1.Columns["NumeEchipa"].HeaderText = "Echipa";
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.AutoResizeColumns();
                }




                //gasire numar pagini si adaugare pe label

                HttpContent content2 = responseNrPagini.Content;
                Task<string> result2 = content2.ReadAsStringAsync();
                string res2 = result2.Result;
                int nrPagini = JsonConvert.DeserializeObject<int>(res2);

                labelPagina.Text = paginaActuala.ToString() + "/" + nrPagini.ToString();
            }
        }
        //buton paginare inapoi
        private void buttonInapoi_Click(object sender, EventArgs e)
        {

        }


        //butoane
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 0;
            this.Close();
        }
        int count = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            count++;

            if(count%2!=0)
            {
                button1.Show();
                button8.Show();
                button9.Show();
                button10.Show();
                button11.Show();

                if (Globals.IsAdmin == true || Globals.IdManager == null)
                {
                    button4.Show();
                    button5.Show();
                    buttonPromovareAngajati.Show();
                    button7.Show();
                }
                if (Globals.IdManager == null && Globals.IsAdmin == false)
                    buttonPromovareAngajati.Hide();

            }
            else
            {
                button1.Hide();
                button4.Hide();
                button5.Hide();
                buttonPromovareAngajati.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form adaugare_angajat = new Aprobare_Angajare();
            this.Hide();
            adaugare_angajat.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }


    }
}


