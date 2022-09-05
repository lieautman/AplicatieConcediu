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


namespace AplicatieConcediu
{
    public partial class Formular_Inregistrare : Form
    {
        public Formular_Inregistrare()
        {
            InitializeComponent();
        }

        //functie legacy de legatura la baza de date
        private void inregistrareLegacy(string nume, string prenume, string data_nastere, string email, string nr_telefon, string cnp, string SerieNrBuletin, string parola, string conf_parola, bool isError)
        {
            //formatare data
            string data_nastere_formatata = data_nastere.Substring(data_nastere.IndexOf(',') + 2, data_nastere.Length - 2 - data_nastere.IndexOf(','));


            string sqlText = "insert into Angajat(Nume, Prenume, Email,Parola, DataAngajarii, DataNasterii, CNP, SeriaNumarBuletin,Numartelefon,Poza,EsteAdmin,ManagerId,Salariu, EsteAngajatCuActeInRegula)" +
                "values('" + nume + "','" + prenume + "','" + email + "','" + parola + "',null ,'" + data_nastere_formatata + "','" + cnp + "','" + SerieNrBuletin + "','" + nr_telefon + "',null,0,null,null,0)";

            Globals.executeNonQuery(sqlText);
            this.Close();
        }

        //functie noua de legatura la baza de date
        private async void inregistrareNew(string nume, string prenume, string data_nastere, string email, string nr_telefon, string cnp, string SerieNrBuletin, string parola, string conf_parola, bool isError) 
        {
            //validari


            //creare angajat si trimis
            HttpClient httpClient = new HttpClient();
            XD.Models.Angajat a = new XD.Models.Angajat();
            a.Nume = nume;
            a.Prenume = prenume;
            //de folosit
            a.DataNasterii = new DateTime();
            a.Email = email;
            a.Numartelefon = nr_telefon;
            a.Cnp = cnp;
            a.SeriaNumarBuletin = SerieNrBuletin;
            a.Parola = parola;


            string jsonString = JsonSerializer.Serialize<XD.Models.Angajat>(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //?nume=aaa&prenume=aaa&email=aaa&parola=aaa&dataNasterii=September%2010.09.2022&cnp=aaa&serieSiNrCI=aaa&numarTelefon=1234567890
            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostAngajatInregistrare/", stringContent);
            response.EnsureSuccessStatusCode();

           



            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            if(res.Equals("Inregistrare efectuata!"))
            {
                this.Close();
            }
            else
            {
                errorProvider1.SetError(button1, res);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //preluare date din text box
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string data_nastere = dateTimePicker1.Text;
            string email = textBox4.Text;
            string nr_telefon = textBox5.Text;
            string cnp = textBox6.Text;
            string SerieNrBuletin = textBox3.Text;
            string parola = textBox7.Text;
            string conf_parola = textBox8.Text;
            bool isError = false;


            //validari
            if (nume == "")
            {
                errorProvider1.SetError(textBox1, "Trebuie completat numele");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");

            }
            if (prenume == "")
            {
                errorProvider1.SetError(textBox2, "Trebuie completat prenumele");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
            if (data_nastere == "")
            {
                errorProvider1.SetError(dateTimePicker1, "Trebuie completata data nasterii");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
            ////data nastere in viitor
            if (DateTime.Parse(data_nastere) > DateTime.Now)
            {
                errorProvider1.SetError(dateTimePicker1, "Trebuie completata data nasterii valida");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
            //if (email == "")
            //{
            //    errorProvider1.SetError(textBox4, "Trebuie completat emailul");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox4, "");
            //}
            //if (cnp == "")
            //{
            //    errorProvider1.SetError(textBox6, "Trebuie completat CNP-ul");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox6, "");
            //}
            //if (parola == "")
            //{
            //    errorProvider1.SetError(textBox7, "Trebuie completata parola");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox7, "");
            //}
            //if (conf_parola == "")
            //{
            //    errorProvider1.SetError(textBox8, "Trebuie completata confirmarea parolei");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox8, "");
            //}
            ////verificare pe nr de caractere
            ////lungimile pot fi preluatedin baza de date (todo)
            //if (nume.Length > 150)
            //{
            //    errorProvider1.SetError(textBox1, "Nume prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox1, "");
            //}
            //if (prenume.Length > 100)
            //{
            //    errorProvider1.SetError(textBox2, "Prenume prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox2, "");
            //}
            //if (email.Length > 100)
            //{
            //    errorProvider1.SetError(textBox4, "Email prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox4, "");
            //}
            //if (nr_telefon.Length > 20)
            //{
            //    errorProvider1.SetError(textBox5, "Numar de telefon prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox5, "");
            //}
            //if (cnp.Length > 13)
            //{
            //    errorProvider1.SetError(textBox6, "Cnp prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox6, "");
            //}
            //if (SerieNrBuletin.Length > 8)
            //{
            //    errorProvider1.SetError(textBox3, "Serie si numar buletin prea mari");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox3, "");
            //}
            //if (parola.Length > 100)
            //{
            //    errorProvider1.SetError(textBox7, "Parola prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox7, "");
            //}
            //if (conf_parola.Length > 100)
            //{
            //    errorProvider1.SetError(textBox8, "Confirmarea parolei prea mare");
            //    isError = true;
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox8, "");
            //}
            //try
            //{
            //    Int32.Parse(nr_telefon);
            //    errorProvider1.SetError(textBox5, "");
            //}
            //catch
            //{
            //    errorProvider1.SetError(textBox5, "Introduceti un numar de telefon valid");
            //    isError = true;
            //}


            //inregistrarea in baza de date a rezultatelor
            if (!isError)
            {

                if (parola == conf_parola)
                {
                    // inregistrareLegacy(nume, prenume, data_nastere, email, nr_telefon, cnp, SerieNrBuletin, parola, conf_parola, isError);
                    inregistrareNew(nume, prenume, data_nastere, email, nr_telefon, cnp, SerieNrBuletin, parola, conf_parola, isError);

                }
                else
                {
                    throw new ArgumentOutOfRangeException("Parola nu corespunde");
                }
            }
        }
    }
}
