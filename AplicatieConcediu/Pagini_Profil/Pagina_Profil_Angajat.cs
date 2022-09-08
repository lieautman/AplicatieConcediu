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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using AplicatieConcediu.Pagini_Actiuni;
using AplicatieConcediu.Pagini_Profil;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using Azure;
using XD.Models;

namespace AplicatieConcediu
{
    public partial class Pagina_Profil_Angajat : Form
    {
        public Pagina_Profil_Angajat()
        {
            InitializeComponent();
        }

        //apelare bkend
        public Angajat GetAngajatByEmail(string emailFolositLaSelect)
        {
            var url = "http://localhost:5107/Angajat/GetDateAngajat/" + emailFolositLaSelect;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Angajat a;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                a  = JsonConvert.DeserializeObject<Angajat>(result);
            }
            return a;
        }
        //load
        private async void Pagina_Profil_Angajat_Load(object sender, EventArgs e)
        {
            


            string emailFolositLaSelect;
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }

            Angajat a = GetAngajatByEmail(emailFolositLaSelect);
            


            //selectare detalii angajat si afisare butoane in functie de rol
            //string query = "SELECT * FROM Angajat WHERE Email ='"+ emailFolositLaSelect+"'";
            //SqlConnection connection = new SqlConnection();
            //SqlDataReader reader = Globals.executeQuery(query,out connection);


            //while(reader.Read())
            //{
           //string nume = (string)reader["Nume"];
           label12.Text = a.Nume;
                //string prenume = (string)reader["Prenume"];
           label13.Text = a.Prenume;
            if (a.EsteAdmin.Value)
            {
                label14.Text = "Administrator";
            }
            else if (a.ManagerId == 0)
            {
                label14.Text = "Manager";
            }
            else
            {
                label14.Text = "Angajat";
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button9.Hide();
                button14.Hide();
            }



            //if (reader["EsteAdmin"] is true)
            //{
            //    label14.Text = "Administrator";
            //    //button4.Show();
            //    //button5.Show();
            //    //button6.Show();
            //   // button9.Show();


            ////}
            //else if (reader["ManagerId"] == DBNull.Value)
            //{
            //    label14.Text = "Manager";
            //   // button4.Show();
            //   // button5.Show();
            //    //button9.Show();
            //}




            if (a.DataAngajarii!=null)
            {
                    label15.Text = a.DataAngajarii.ToString();
            }
                else
                {
                    label15.Text = "Acest angajat nu a fost inca acceptat!";
                }
                
                label16.Text = a.Email;
                //string telefon = (string)reader["Numartelefon"];
                label17.Text = a.Numartelefon;
                //DateTime data_nastere = (DateTime)reader["DataNasterii"];
                label18.Text = a.DataNasterii.ToString();/*data_nastere.ToString().Substring(0,10);*/
                                                         //string cnp = (string)reader["CNP"];
                                                         //label19.Text = cnp;
            label19.Text = a.CNP;
            //string serie_numar = (string)reader["SeriaNumarBuletin"];
             label20.Text = a.SeriaNumarBuletin.Substring(0, 2);
             label21.Text = a.SeriaNumarBuletin.Substring(2);
            //string salariu = reader["Salariu"].ToString();
            label22.Text = a.Salariu.ToString();




            //creare conexiune pentru a cere o poza
            //LEGACY:
            //byte[] poza = { };
            //bool isOk = true;
            //string query1 = "SELECT Poza FROM Angajat WHERE Email ='" + emailFolositLaSelect + "'";
            //SqlConnection connection1 = new SqlConnection();
            //SqlDataReader reader1 = Globals.executeQuery(query1, out connection1);

            //while (reader1.Read()) 
            //{
            //    if (reader1["Poza"] != DBNull.Value)
            //        poza = (byte[])reader1["Poza"];
            //    else
            //        isOk = false;

            //}
            //reader1.Close();
            //connection1.Close();
            //if(isOk==true)
            //    pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));

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

            XD.Models.Angajat ang1 = JsonConvert.DeserializeObject<XD.Models.Angajat>(res);

            if (ang1.Poza != null)
                poza = ang1.Poza;
            else
                isOk = false;

            if (isOk==true)
                pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));




            //afisare butoane daca este nevoie
            if (Globals.EmailUserViewed != "")
            {
                button7.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
        }


        //adaugare poza
        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Globals.EmailUserViewed == "")
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


                        //trimmite poza legacy
                        //SqlConnection conn = new SqlConnection(Globals.ConnString);
                        //SqlCommand cmd = new SqlCommand();

                        //cmd.Connection = conn;
                        //cmd.CommandText = "update Angajat set Poza= @imgdata where Email = @email";

                        //SqlParameter photo = new SqlParameter("@imgdata", bytes);
                        //cmd.Parameters.Add(photo);

                        //SqlParameter email = new SqlParameter("@email", Globals.EmailUserActual);
                        //cmd.Parameters.Add(email);


                        //conn.Open();
                        //cmd.ExecuteNonQuery();
                        //conn.Close();


                        //trimite poza new
                        HttpClient httpClient = new HttpClient();
                        XD.Models.Angajat angajat1 = new XD.Models.Angajat();
                        angajat1.Email = Globals.EmailUserActual;
                        angajat1.Poza = bytes;
                        angajat1.Cnp = "";
                        angajat1.Nume = "";
                        angajat1.Prenume = "";

                        string jsonString = JsonConvert.SerializeObject(angajat1);
                        StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostIncarcarePoza", stringContent);
                        response.EnsureSuccessStatusCode();

                        pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                    }
                }
            }
        }

        //buton vizualizare profil
        private void button12_Click(object sender, EventArgs e)
        {
            Form profilul_meu = new Pagina_Profil_Angajat();

            this.Hide();
            this.Close();
            Globals.EmailUserViewed = "";
            profilul_meu.ShowDialog();
        }
        //buton pagina cu toate echipele
        private void button8_Click_1(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        //buton vizualizare angajati
        private void button11_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();

            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();

        }
        //buton pagina creare concediu
        private void button14_Click_1(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
        //buton aprobare concedii
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }
        //buton promovare angajat
        private void button6_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();

        }
        //buton aprobare angajat
        private void button4_Click_1(object sender, EventArgs e)
        {
            Form adaugare_angajat = new Aprobare_Angajare();
            this.Hide();
            adaugare_angajat.ShowDialog();
            this.Show();
        }
        //buton adaugare angajat  nou
        private void button9_Click_1(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }


        //delogare
        private void button13_Click_1(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);

        }


        //buton creare concediu
        private void button3_Click(object sender, EventArgs e)
        {
            Form creareconcediu = new Pagina_CreareConcediu();
            this.Hide();
            creareconcediu.ShowDialog();
            this.Show();
        }
        //buton concediile mele
        private void button1_Click(object sender, EventArgs e)
        {
            Form concedii = new Pagina_ConcediileMele();
            this.Hide();
            concedii.ShowDialog();
            this.Show();
        }
        //buton concediile sale
        private void button7_Click(object sender, EventArgs e)
        {
            Pagina_ConcediileMele concediilemele = new Pagina_ConcediileMele();
            this.Hide();
            concediilemele.ShowDialog();
            this.Show();
        }


        //buton inchidere
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.EmailUserViewed = "";
            this.Close();
        }



        //afisare butoane sau nu
        int count = 1;
        private void button10_Click(object sender, EventArgs e)
        {
            count++;
            if (count % 2 != 0)
            {
                button8.Show();
                button11.Show();
                button12.Show();
                button13.Show();

                if (Globals.IsAdmin == true || Globals.IdManager == null)
                {
                    button8.Show();
                    button5.Show();
                    button6.Show();
                    button9.Show();
                    button4.Show();
                    button14.Show();
                }

            }
            else
            {
                button8.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button9.Hide();
                button11.Hide();
                button12.Hide();
                button13.Hide();
                button14.Hide();

            }

        }
    }
}
