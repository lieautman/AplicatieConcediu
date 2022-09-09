using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Azure;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AplicatieConcediu
{
    public partial class Formular_Inregistrare : Form
    {
        public Formular_Inregistrare()
        {
            InitializeComponent();
        }

       
        //functie noua de legatura la baza de date
        private async Task inregistrareNew(string nume, string prenume, DateTime data_nastere, string email, string nr_telefon, string cnp, string SerieNrBuletin, string parola, string conf_parola, bool isError) 
        {


            //creare angajat si trimis
            HttpClient httpClient = new HttpClient();
            XD.Models.Angajat a = new XD.Models.Angajat();
            a.Nume = nume;
            a.Prenume = prenume;
            a.DataNasterii = data_nastere;
            a.Email = email;
            a.Numartelefon = nr_telefon;
            a.Cnp = cnp;
            a.SeriaNumarBuletin = SerieNrBuletin;
            a.Parola = parola;



            string jsonString = JsonConvert.SerializeObject(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostAngajatInregistrare/", stringContent);
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            if (res.Equals("Inregistrare efectuata!"))
            {
                //reset textboxuri
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                labelEroareServer.Text = "* Inregistrare efectuata!";
            }
            else
            {
                if (res.Equals("Email existent!"))
                {
                    labelEroareEmail.Text = "* Exista deja un cont cu acest email.";
                }
                else
                {
                    labelEroareServer.Text = "* A aparut o eroare de server.";
                }
            }
        }
       
        //buton inregistrare
        private async void button1_Click(object sender, EventArgs e)
        {
            //preluare date din text box
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            DateTime data_nastere_DateTime = dateTimePicker1.Value.Date;
            string email = textBox4.Text;
            string nr_telefon = textBox5.Text;
            string cnp = textBox6.Text;
            string SerieNrBuletin = textBox3.Text;
            string parola = textBox7.Text;
            string conf_parola = textBox8.Text;
            bool isError = false;


            //validari
            //completare campuri
            if (!isError)
            {
                if (nume == "")
                {
                    labelEroareNume.Text = "* Trebuie completat numele";
                    isError = true;
                }
                if (prenume == "")
                {
                    labelEroarePrenume.Text = "* Trebuie completat prenumele";
                    isError = true;
                }
                if (nr_telefon == "")
                {
                    labelEroareNumarTelefon.Text = "* Trebuie completat numarul de telefon";
                    isError = true;
                }
                if (cnp == "")
                {
                    labelEroareCnp.Text = "* Trebuie completat CNP-ul";
                    isError = true;
                }
                if (SerieNrBuletin == "")
                {
                    labelEroareSerieNumarCi.Text = "* Trebuie completata seria si numarul buletinului";
                    isError = true;
                }
                if (parola == "")
                {
                    labelEroareParola1.Text = "* Trebuie completata parola";
                    isError = true;
                }
                if (conf_parola == "")
                {
                    labelEroareParola2.Text = "* Trebuie adaugata completarea parolei";
                    isError = true;
                }
                if (email == "")
                {
                    labelEroareEmail.Text = "* Trebuie completat emailul";
                    isError = true;
                }
            }//empty sring
            if (!isError)
            {
                if (nume == null)
                {
                    labelEroareNume.Text = "* Trebuie completat numele";
                    isError = true;
                }
                if (prenume == null)
                {
                    labelEroarePrenume.Text = "* Trebuie completat prenumele";
                    isError = true;
                }
                if (nr_telefon == null)
                {
                    labelEroareNumarTelefon.Text = "* Trebuie completat numarul de telefon";
                    isError = true;
                }
                if (cnp == null)
                {
                    labelEroareCnp.Text = "* Trebuie completat CNP-ul";
                    isError = true;
                }
                if (SerieNrBuletin == null)
                {
                    labelEroareSerieNumarCi.Text = "* Trebuie completata seria si numarul buletinului";
                    isError = true;
                }
                if (parola == null)
                {
                    labelEroareParola1.Text = "* Trebuie completata parola";
                    isError = true;
                }
                if (conf_parola == null)
                {
                    labelEroareParola2.Text = "* Trebuie adaugata completarea parolei";
                    isError = true;
                }
                if (email == null)
                {
                    labelEroareEmail.Text = "* Trebuie completat emailul";
                    isError = true;
                }
            }//null

            //TODO: lungimile pot fi preluatedin baza de date
            //verificare pe nr de caractere minime
            if (!isError)
            {
                if (nume.Length < 2)
                {
                    labelEroareNume.Text = "* Nume prea mic";

                    isError = true;
                }
                if (prenume.Length < 2)
                {
                    labelEroarePrenume.Text = "* Prenume prea mic";

                    isError = true;
                }
                //dataNastere nu are
                if (nr_telefon.Length < 10)
                {
                    labelEroareNumarTelefon.Text = "* Numar de telefon prea mic";
                    isError = true;
                }
                if (cnp.Length < 13)
                {
                    labelEroareCnp.Text = "* Cnp prea mic";
                    isError = true;
                }
                if (SerieNrBuletin.Length < 6)
                {
                    labelEroareSerieNumarCi.Text = "* Serie si numar buletin prea mic";
                    isError = true;
                }
                if (parola.Length < 3)
                {
                    labelEroareParola1.Text = "* Parola prea mica";

                    isError = true;
                }
                if (conf_parola.Length < 3)
                {
                    labelEroareParola2.Text = "* Confirmare parolei prea mica";

                    isError = true;
                }
                if (email.Length < 3)
                {
                    labelEroareEmail.Text = "* Email prea mic";

                    isError = true;
                }
            }
            //verificare pe nr de caractere maxime
            if (!isError)
            {
                if (nume.Length > 150)
                {
                    labelEroareNume.Text = "* Nume prea mare";

                    isError = true;
                }
                if (prenume.Length > 150)
                {
                    labelEroarePrenume.Text = "* Prenume prea mare";

                    isError = true;
                }
                //dataNastere nu are
                if (nr_telefon.Length > 20)
                {
                    labelEroareNumarTelefon.Text = "* Numar de telefon prea mare";
                    isError = true;
                }
                if (cnp.Length > 20)
                {
                    labelEroareCnp.Text = "* Cnp prea mare";
                    isError = true;
                }
                if (SerieNrBuletin.Length > 8)
                {
                    labelEroareSerieNumarCi.Text = "* Serie si numar buletin prea mari";
                    isError = true;
                }
                if (parola.Length > 100)
                {
                    labelEroareParola1.Text = "* Parola prea mare";

                    isError = true;
                }
                if (conf_parola.Length > 100)
                {
                    labelEroareParola2.Text = "* Confirmare parolei prea mare";

                    isError = true;
                }
                if (email.Length > 100)
                {
                    labelEroareEmail.Text = "* Email prea mare";

                    isError = true;
                }
            }

            //verificare validitate date campuri
            if (!isError)
            {
                const string reTelefon = "^[0-9]*$";
                if (!Regex.Match(nr_telefon, reTelefon, RegexOptions.IgnoreCase).Success)
                {
                    labelEroareNumarTelefon.Text = "* Introduceti un numar de telefon valid";
                    isError = true;
                }
                const string reCnp = "^[0-9]*$";
                if (!Regex.Match(cnp, reCnp, RegexOptions.IgnoreCase).Success)
                {
                    labelEroareCnp.Text = "* Introduceti un cnp valid";
                    isError = true;
                }
                //validare email
                const string reEmail = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
                if (!Regex.Match(email, reEmail, RegexOptions.IgnoreCase).Success)
                {
                    labelEroareEmail.Text = "* Introduceti un email valid";
                    isError = true;
                }
                //data nastere in viitor
                if (data_nastere_DateTime > DateTime.Now)
                {
                    labelEroareDataNastere.Text = "* Data de nastere in viitor";
                    isError = true;
                }
            }


            //inregistrarea in baza de date a rezultatelor
            if (!isError)
            {
                if (parola == conf_parola)
                {
                    await inregistrareNew(nume, prenume, data_nastere_DateTime, email, nr_telefon, cnp, SerieNrBuletin, parola, conf_parola, isError);
                }
                else
                {
                    labelEroareParola1.Text = "* Parolele nu sunt similare";
                }
            }
        }
        
        //stergere erori la modificare text pe toate butoanele
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labelEroareNume.Text = "";
            labelEroareServer.Text = "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            labelEroarePrenume.Text = "";
            labelEroareServer.Text = "";
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            labelEroareDataNastere.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            labelEroareNumarTelefon.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            labelEroareCnp.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            labelEroareSerieNumarCi.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            labelEroareParola1.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            labelEroareParola2.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            labelEroareEmail.Text = "";
            labelEroareServer.Text = "";

        }

        //stergere text label la load
        private void Formular_Inregistrare_Load(object sender, EventArgs e)
        {
            labelEroareNume.Text = "";
            labelEroarePrenume.Text = "";
            labelEroareDataNastere.Text = "";
            labelEroareCnp.Text = "";
            labelEroareNumarTelefon.Text = "";
            labelEroareCnp.Text = "";
            labelEroareSerieNumarCi.Text = "";
            labelEroareParola1.Text = "";
            labelEroareParola2.Text = "";
            labelEroareEmail.Text = "";
            labelEroareServer.Text = "";
        }

        //buton inapoi
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
