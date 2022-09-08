﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using AplicatieConcediu.Properties;
using System.Web;
using Azure;
using XD.Models;
using System.Runtime;
using Echipa = XD.Models.Echipa;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class FormareEchipaAngajatPromovat : Form
    {
        private List<AngajatiListaPentruFormareEchipaNoua> listaAngajati = new List<AngajatiListaPentruFormareEchipaNoua>();
        List<XD.Models.Angajat> lista2 = new List<XD.Models.Angajat>();
        private List<AfisareAngajati> listaAngajati2 = new List<AfisareAngajati>();
        List<XD.Models.Angajat> lista = new List<XD.Models.Angajat>();
        private List<AfisareAngajati> listaAngajatiAdaugati = new List<AfisareAngajati>();
        private List<Echipa> numeEchipa = new List<Echipa>();
        private int IDECHIPAPOZA = 1;
        private string emailSelectat = "";


        public FormareEchipaAngajatPromovat()
        {
            InitializeComponent();
        }

        private void AngajatideAdaugatLegacy()
        {
            //inserare in gridview date despre angajati(care nu sunt si manageri)-varianta veche
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("Select Nume, Prenume, Email,DataAngajarii, DataNasterii, CNP, IdEchipa, ManagerId from Angajat where Email !='" + Globals.EmailManager + "'", out conn);
            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                DateTime dataAngajarii;
                if (reader[4] != DBNull.Value)
                    dataAngajarii = (DateTime)reader[4];
                else dataAngajarii = (DateTime)reader[""];


                DateTime dataNasterii = (DateTime)reader["DataNasterii"];
                string cNP = (string)reader["CNP"];
                int idEchipaa = 0;
                if (reader[6] != DBNull.Value)
                {
                    idEchipaa = Convert.ToInt32(reader.GetValue(6));
                }


                int managerId = 0;
                if (reader["ManagerId"] != DBNull.Value)
                {
                    managerId = Convert.ToInt32(reader["managerId"]);
                }

                AngajatiListaPentruFormareEchipaNoua angajat = new AngajatiListaPentruFormareEchipaNoua(nume, prenume, email, dataAngajarii, dataNasterii, cNP, idEchipaa, managerId);
                listaAngajati.Add(angajat);
            }

            dataGridView1.DataSource = listaAngajati;

            conn.Close();

            //inserare in lable nume si prenume angajat din bd
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Nume, Prenume, Id from Angajat where Email = '" + Globals.EmailManager + "'", out conn1);
            string numesiprenume = "";
            while (reader1.Read())
            {
                numesiprenume += reader1["Nume"];
                numesiprenume += " ";
                numesiprenume += reader1["Prenume"];
                Globals.IdManager = (int)reader1["Id"];
            }
            reader1.Close();
            conn1.Close();
            label3.Text = numesiprenume;



            //atribuire poza pe form load in functie de id logat
            byte[] poza = { };
            bool isOk = true;
            string query2 = "SELECT Poza FROM Angajat WHERE Email ='" + Globals.EmailManager + "'";
            SqlConnection connection2;
            SqlDataReader reader2 = Globals.executeQuery(query2, out connection2);

            while (reader2.Read())
            {
                if (reader2["Poza"] != DBNull.Value)
                    poza = (byte[])reader2["Poza"];
                else
                    isOk = false;

            }
            reader2.Close();
            connection2.Close();
            if (isOk == true)
                pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));


            //combobox
            using (SqlConnection connEchipa = new SqlConnection(Globals.ConnString))
            {
                string query = string.Format("select Nume from Echipa");

                //definire comenzi
                SqlCommand cmd = new SqlCommand(query, connEchipa);
                connEchipa.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                //verificare existenta inregistrari
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var echipa = new Echipa();
                        var y = dr.GetValue(0);
                        echipa.Nume = y.ToString();
                        numeEchipa.Add(echipa);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
                dr.Close();

                connEchipa.Close();

                comboBox1.DataSource = numeEchipa;
                comboBox1.DisplayMember = "Nume";
                comboBox1.ValueMember = "Id";

                //update angajat la manager, setare managerId ca null
                string updatare = "UPDATE Angajat set ManagerId= null Where Email='" + Globals.EmailManager + "'";
                SqlConnection connection4 = new SqlConnection();
                SqlDataReader reader4 = Globals.executeQuery(updatare, out connection4);
                connection4.Close();
            }
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

        public Angajat NumePrenumeAngajat(string emailFolositLaSelect)
        {

            var url = "http://localhost:5107/Angajat/NumePrenumeAngajat?email=" + emailFolositLaSelect;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Angajat a;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                a = JsonConvert.DeserializeObject<Angajat>(result);
            }
            return a;

        }

        private async Task PozaAngajat(string emailFolositLaSelect)
        {
            byte[] poza = { };
            bool isOk = true;


            HttpClient httpClient = new HttpClient();
            XD.Models.Angajat angajat1 = new XD.Models.Angajat();
            angajat1.Email = emailFolositLaSelect;
            angajat1.Cnp = "";
            angajat1.Nume = "";
            angajat1.Prenume = "";
            string jsonString = JsonConvert.SerializeObject(angajat1);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostPreluarePoza", stringContent);
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };

            XD.Models.Angajat ang1 = JsonConvert.DeserializeObject<XD.Models.Angajat>(res, settings);

            if (ang1.Poza != null)
                poza = ang1.Poza;
            else
                isOk = false;

            if (isOk == true)
                pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));
        }

        private async Task UpdateManagerIdEchipaId(string emailManager)
        {
            //listaAngajatiAdaugati
            HttpClient httpClient = new HttpClient();
            XD.Models.Angajat managerId = new XD.Models.Angajat();
            managerId.Email=emailManager;
            managerId.Cnp = "";
            managerId.Nume = "";
            managerId.Prenume = "";
            string jsonString = JsonConvert.SerializeObject(managerId);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PreluareAngajatDupaEmail", stringContent);

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            XD.Models.Angajat ang1 = JsonConvert.DeserializeObject<XD.Models.Angajat>(res);

            List<XD.Models.Angajat> ListaAngajatTrimisInBk = new List<XD.Models.Angajat>();

            foreach (var angajat in lista)
            {
                angajat.ManagerId = ang1.Id;
                angajat.IdEchipa = IDECHIPAPOZA;
                if (angajat.Cnp == null)
                {
                    angajat.Cnp = "";
                }
                ListaAngajatTrimisInBk.Add(angajat);
            }
            ang1.IdEchipa = IDECHIPAPOZA;
            ang1.ManagerId = null;
            if (ang1.Cnp == null)
            {
                ang1.Cnp = "";
            }
            ListaAngajatTrimisInBk.Add(ang1);

            HttpClient httpClient1 = new HttpClient();
            string jsonString1 = JsonConvert.SerializeObject(ListaAngajatTrimisInBk);
            StringContent stringContent1 = new StringContent(jsonString1, Encoding.UTF8, "application/json");
            var response1 = await httpClient.PostAsync("http://localhost:5107/api/PromovareAngajat/UpdateManagerIdEchipaId", stringContent1);
            this.Close();
        }


        private async Task PozaEchipa(int IDECHIPAPOZA)
        {
            byte[] poza = { };
            bool isOk = true;


            HttpClient httpClient = new HttpClient();
            XD.Models.Echipa pozaEchipa = new XD.Models.Echipa();
            IDECHIPAPOZA = comboBox1.SelectedIndex + 1;
            pozaEchipa.Id = IDECHIPAPOZA;
            pozaEchipa.Nume = "";
            pozaEchipa.Descriere = "";
            string jsonString = JsonConvert.SerializeObject(pozaEchipa);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.GetAsync("http://localhost:5107/Echipa/PozaEchipa?id=" + IDECHIPAPOZA);

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            byte[] echipaP = null;

            if (response.StatusCode == HttpStatusCode.OK)
                echipaP = System.Text.Json.JsonSerializer.Deserialize<byte[]>(res);
            else
                isOk = false;

            // JsonConvert.DeserializeObject<List<XD.Models.Echipa>>(res, settings);


            if (echipaP != null)
                poza = echipaP;
            else
                MessageBox.Show("Nu exista poza  echipei in baza de date");


            if (isOk == true)
                pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));
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

        private async void FormareEchipaAngajatPromovat_Load(object sender, EventArgs e)
        {
            //inserare in gridview pentru angajati (managerId != null)

            lista2 =PromovareAngajati();

            foreach (var angajat in lista2)
            {
                AfisareAngajati afisareAngajati = new AfisareAngajati();
                afisareAngajati.Nume = angajat.Nume;
                afisareAngajati.Prenume = angajat.Prenume;
                afisareAngajati.Email = angajat.Email;
                afisareAngajati.DataNasterii = angajat.DataNasterii;
                afisareAngajati.Numartelefon = angajat.Numartelefon;
                afisareAngajati.NumeEchipa = angajat.IdEchipa.ToString();

                listaAngajati2.Add(afisareAngajati);
            }

            dataGridView1.DataSource = listaAngajati2;



            //citire din bd  nume si prenume angajat intr-un label
            string emailFolositLaSelect = "";
            if (Globals.EmailManager != "")
            {
                emailFolositLaSelect = Globals.EmailManager;
            }

            Angajat a = NumePrenumeAngajat(emailFolositLaSelect);


            string numesiprenume = a.Nume + " " + a.Prenume;

            label3.Text = numesiprenume;



            //afisare poza angajat
            await PozaAngajat(emailFolositLaSelect);


            //aducere nume echipe in combobox

            comboBox1.DataSource = NumeEchipa();
            comboBox1.DisplayMember = "Nume";
            comboBox1.ValueMember = "Id";


        }

        private async void button1_Click(object sender, EventArgs e)
        {

            //TO-DO
            //api update managerid in null si id ul de echipa in id ul echipei selectate din combo box
            //api update echipa id al angajatului in id ul echipei selectate din combobox si id ul managerului
            //cu id ul celui selectat
            //toate astea pentru angajatii din gridview2

            string emailManager = Globals.EmailManager;
            await UpdateManagerIdEchipaId( emailManager);



            //selectare echipa din combobox
            //int id = comboBox1.SelectedIndex + 1;
            //string updatare = "UPDATE Angajat set IdEchipa= '" + id + "', ManagerId= '" + Globals.IdManager + "'Where Email='" + emailSelectat + "'";
            //SqlConnection connection3 = new SqlConnection();
            //SqlDataReader reader3 = Globals.executeQuery(updatare, out connection3);
            //connection3.Close();


            //refresh fortat
            //FormareEchipaAngajatPromovat f = new FormareEchipaAngajatPromovat();
            //this.Hide();
            //this.Close();
            //f.ShowDialog();


        }
        /*TO-DO
         * - de facut ca id ul de manager al angajatului selectat pentru a fi adaugat in echipa noului manager sa se schimbe in id ul managerului
         * proaspat promovat
         * - idManager de la angajatul promovat sa devina null
         * - angajatul promovat sa dispara din lista initiala cu toti angajatii buni de promovat
         * -poza pentru echipa pe pagina de promovare
         */

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //la schimbare de combo box, poza trebuie sa se modifice si un id global(pe formular) treb sa se schimbe

            await PozaEchipa(IDECHIPAPOZA);

            //pictureBox2.Image = null;

            //byte[] poza2 = { };
            //bool isOk2 = true;
            //int id = IDECHIPAPOZA;

            //    pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza2));

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {




            //deschidere file explorer pt a citi o poza
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    byte[] bytes = File.ReadAllBytes(fileName);
                    string contentType = "";
                    //Set the contenttype based on File Extension

                    switch (Path.GetExtension(fileName))
                    {
                        case ".jpg":
                            contentType = "image/jpeg";
                            break;
                        case ".png":
                            contentType = "image/png";
                            break;
                        case ".gif":
                            contentType = "image/gif";
                            break;
                        case ".bmp":
                            contentType = "image/bmp";
                            break;
                    }


                    SqlConnection conn = new SqlConnection(Globals.ConnString);
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "update Echipa set Poza= @imgdata where Id = @id";

                    SqlParameter photo = new SqlParameter("@imgdata", bytes);
                    cmd.Parameters.Add(photo);

                    SqlParameter id = new SqlParameter("@id", IDECHIPAPOZA);
                    cmd.Parameters.Add(id);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            emailSelectat = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
        }

        //buton inapoi
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //List<AfisareAngajati> angajatiDeSelectat = new List<AfisareAngajati>();
            //List<AfisareAngajati> angajatiSelectati = new List<AfisareAngajati>();






            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            // DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            listaAngajatiAdaugati.Add(listaAngajati2[selectedrowindex]);
            listaAngajati2.Remove(listaAngajati2[selectedrowindex]);

            lista.Add(lista2[selectedrowindex]);
            lista2.Remove(lista2[selectedrowindex]);


            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            dataGridView1.DataSource = listaAngajati2;
            dataGridView2.DataSource = listaAngajatiAdaugati;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

            listaAngajati2.Add(listaAngajatiAdaugati[selectedrowindex]);
            listaAngajatiAdaugati.Remove(listaAngajatiAdaugati[selectedrowindex]);


            lista2.Add(lista[selectedrowindex]);
            lista.Remove(lista[selectedrowindex]);


            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            dataGridView1.DataSource = listaAngajati2;
            dataGridView2.DataSource = listaAngajatiAdaugati;

        }
    }
}
