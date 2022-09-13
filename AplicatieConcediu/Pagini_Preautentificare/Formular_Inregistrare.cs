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
                textBoxNume.Text = "";
                textBoxPrenume.Text = "";
                textBoxSerieSiNumarCi.Text = "";
                textBoxEmail.Text = "";
                textBoxNumarDeTelefon.Text = "";
                textBoxCnp.Text = "";
                textBoxParola1.Text = "";
                textBoxParola2.Text = "";
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
        private async void buttonInregistrare_Click(object sender, EventArgs e)
        {
            //preluare date din text box
            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            DateTime data_nastere_DateTime = dateTimePickerDataNastere.Value.Date;
            string email = textBoxEmail.Text;
            string nr_telefon = textBoxNumarDeTelefon.Text;
            string cnp = textBoxCnp.Text;
            string SerieNrBuletin = textBoxSerieSiNumarCi.Text;
            string parola = textBoxParola1.Text;
            string conf_parola = textBoxParola2.Text;
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
                //cnp si data nasterii corespund
                {
                    string cnpDataNastere = cnp.Substring(1, 6);
                    string dataNastereFormatataString = dateTimePickerDataNastere.Text;
                    int index = dataNastereFormatataString.IndexOf('/', dataNastereFormatataString.IndexOf('/') + 1);
                    string luna = dataNastereFormatataString.Substring(0, dataNastereFormatataString.IndexOf("/"));
                    string zi = dataNastereFormatataString.Substring(dataNastereFormatataString.IndexOf("/")+1, index-dataNastereFormatataString.IndexOf("/")-1);
                    string an = dataNastereFormatataString.Substring(index+1+2, dataNastereFormatataString.Length - index-1-2);

                    if (zi.Length == 1)
                    {
                        zi = "0" + zi;
                    }
                    if (luna.Length == 1)
                    {
                        luna = "0" + luna;
                    }

                    if (cnpDataNastere!= an+luna+zi)
                    {
                        labelEroareCnp.Text = "* Cnp sau data nastere invalida";
                        labelEroareDataNastere.Text = "* Cnp sau data nastere invalida";
                        isError = true;
                    }
                }

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
                //validare parola
                const string reParola = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
                if (!Regex.Match(parola, reParola, RegexOptions.IgnoreCase).Success)
                {
                    labelEroareParola1.Text = "Parola trebuie sa contina 8 caractere dintre care o majuscula si un caracter special";
                    isError = true;
                }


                const string reSeriaNumarCI = "^[a-zA-Z]{2}[0-9]{6}$";
                if (Regex.Match(SerieNrBuletin, reSeriaNumarCI, RegexOptions.IgnoreCase).Success == false)
                {
                    isError = true;
                    labelEroareSerieNumarCi.Text = "SeriaNumar CI trebuie sa contina 2 litere si 6 cifre";
                }
                else
                {
                    labelEroareSerieNumarCi.Text = "";
                }
                //data nastere in viitor
                if (data_nastere_DateTime > DateTime.Now)
                {
                    labelEroareDataNastere.Text = "* Data de nastere in viitor";
                    isError = true;
                }
                const string reNume = "^[a-zA-Z]+$";
                if(!Regex.Match(nume, reNume, RegexOptions.IgnoreCase).Success)
                {
                    isError = true;
                    labelEroareNume.Text = "Numele trebuie sa contina doar litere";
                }
                const string rePrenume = "^[a-zA-Z]+$";
                if(!Regex.Match(prenume, rePrenume,RegexOptions.IgnoreCase).Success)
                {
                    isError=true;
                    labelEroarePrenume.Text = "Prenumele trebuie sa contina doar litere";
                }

                // validare prima cifra din cnp
                string cnpcifra = cnp.Substring(0, 1);

                int an1 = Int32.Parse(dateTimePickerDataNastere.Value.Year.ToString()); 
                if (an1 < 2000)
                {
                    if (Equals(cnpcifra, "5") == true || Equals(cnpcifra, "6") == true)
                    {
                        isError = true;
                        labelEroareCnp.Text = "* Cnp incorect";
                    }

                }
                else if (an1 >= 2000)
                {
                    if ((Equals(cnpcifra, "1") == true) || (Equals(cnpcifra, "2") == true))
                    {
                        isError = true;
                        labelEroareCnp.Text = "* Cnp incorect";
                    }


                }

                

            }


            //inregistrarea in baza de date a rezultatelor
            if (!isError)
            {
                if (parola == conf_parola)
                {
                    await inregistrareNew(nume, prenume, data_nastere_DateTime, email, nr_telefon, cnp, SerieNrBuletin, parola, conf_parola, isError);
                    MessageBox.Show("Contul a fost creat");
                    Form autentificare = new Formular_Autentificare();
                    autentificare.Show();
                    this.Close();
                }
                else
                {
                    labelEroareParola1.Text = "* Parolele nu sunt similare";
                }
            }
        }
        
        //stergere erori la modificare text pe toate butoanele
        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
            labelEroareNume.Text = "";
            labelEroareServer.Text = "";
        }
        private void textBoxPrenume_TextChanged(object sender, EventArgs e)
        {
            labelEroarePrenume.Text = "";
            labelEroareServer.Text = "";
        }
        private void dateTimePickerDataNastere_ValueChanged(object sender, EventArgs e)
        {
            labelEroareDataNastere.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxNumarDeTelefon_TextChanged(object sender, EventArgs e)
        {
            labelEroareNumarTelefon.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxCnp_TextChanged(object sender, EventArgs e)
        {
            labelEroareCnp.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxSerieNumarCi_TextChanged(object sender, EventArgs e)
        {
            labelEroareSerieNumarCi.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxParola1_TextChanged(object sender, EventArgs e)
        {
            labelEroareParola1.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxParoal2_TextChanged(object sender, EventArgs e)
        {
            labelEroareParola2.Text = "";
            labelEroareServer.Text = "";

        }
        private void textBoxEmail_TextChanged(object sender, EventArgs e)
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
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelEroareEmail_Click(object sender, EventArgs e)
        {

        }

        private void labelEroareServer_Click(object sender, EventArgs e)
        {

        }
    }
}
