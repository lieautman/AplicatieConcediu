using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AplicatieConcediu.DB_Classess;
using System.Xml.Linq;
using Azure;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Net.Http;
using System.IO;
using System.Net;


namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Adaugare_Angajat_Nou : Form
    {
        private List<Echipa> listaEchipe = new List<Echipa>();
        private List<Angajat> listaManageri = new List<Angajat>();
        private List<Echipa> ToateEchipele = new List<Echipa>();
        public Adaugare_Angajat_Nou()
        {
            InitializeComponent();
        }
        public List<XD.Models.Angajat> GetManageri()
        {
            var url = "http://localhost:5107/Angajat/GetManageri";
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
        public XD.Models.Angajat GetAngajat(string email)
        {
            var url = String.Format("http://localhost:5107/Angajat/GetDateAngajat/", email);
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            XD.Models.Angajat a = new XD.Models.Angajat();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                a = JsonConvert.DeserializeObject<XD.Models.Angajat>(result, settings);
            }
            return a;
        }
        public List<XD.Models.Echipa> GetEchipe()
        {
            var url = "http://localhost:5107/Angajat/GetEchipe";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Echipa> list = new List<XD.Models.Echipa>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.Echipa>>(result, settings);
            }
            return list;
        }


        private void button1_Click(object sender, EventArgs e) // buton back
        {
            this.Close();
        }
        private void adaugareLegacy(string nume, string prenume, string data_nastere, string email, string nr_telefon, string cnp, string SerieNrBuletin, string parola, int numarzileconcediu, int managerid, bool esteangajatcuacteinregula, string salariu, string data_angajarii, int idechipa, bool isError)
        {
            // formatare data
            string data_nastere_formatata = data_nastere.Substring(data_nastere.IndexOf(',') + 2, data_nastere.Length - 2 - data_nastere.IndexOf(','));
            string data_angajarii_formatata = data_angajarii.Substring(data_angajarii.IndexOf(',') + 2, data_angajarii.Length - 2 - data_angajarii.IndexOf(','));
            int IdManager = comboBox2.SelectedIndex + 1;
            int IdEchipa = comboBox1.SelectedIndex + 1;
            string sqlText = "insert into Angajat(Nume, Prenume, Email,Parola, DataAngajarii, DataNasterii, CNP, SeriaNumarBuletin,Numartelefon,Poza,EsteAdmin,NumarZileConceiduRamase,ManagerId,Salariu, EsteAngajatCuActeInRegula,IdEchipa)" +
                "values('" + nume + "','" + prenume + "','" + email + "','" + parola + "','" + data_angajarii_formatata + "' ,'" + data_nastere_formatata + "','" + cnp + "','" + SerieNrBuletin + "','" + nr_telefon + "',null,0,'" + numarzileconcediu + "','" + IdManager + "','" + salariu + "','" + 1 + "','" + IdEchipa + "')";

            Globals.executeNonQuery(sqlText);
            this.Close();
        }
        // functia noua care face legatura la baza de date
        private async Task adaugareNew(string nume, string prenume, DateTime data_nastere, string email, string nr_telefon, string cnp, string SerieNrBuletin, string parola, int numarzileconcediu, int managerid, bool esteangajatcuacteinregula, decimal salariu, DateTime data_angajarii, int idechipa, bool isError)
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
            a.DataAngajarii = data_angajarii;
            a.ManagerId = managerid;
            a.Salariu = salariu;
            a.NumarZileConceiduRamase = numarzileconcediu;
            a.IdEchipa = idechipa;
            a.EsteAngajatCuActeInRegula = esteangajatcuacteinregula;


            string jsonString = JsonConvert.SerializeObject(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:5107/AdaugareAngajatNou/PostAdaugareAngajatNou", stringContent);
            response.EnsureSuccessStatusCode();
            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;



        }


        List<Angajat> listadeManageri = new List<Angajat>();
        List<int> listaIduri = new List<int>();

        private void Adaugare_Angajat_Nou_Load(object sender, EventArgs e)
        {    //comboBox pt toti Managerii mai putin pt cel logat

            List<XD.Models.Angajat> listaAngajati = GetManageri();
            foreach (var angajat in listaAngajati)
            {
                Angajat a = new Angajat();
                a.id = angajat.Id;
                a.Nume = angajat.Nume;
                a.Prenume = angajat.Prenume;
                listadeManageri.Add(a);
                listaIduri.Add(a.id);

            }
            comboBox2.DataSource = listadeManageri;
            comboBox2.DisplayMember = "NumeComplet";
            comboBox2.ValueMember = "Id";

            //comboBox toate echipele
            List<XD.Models.Echipa> listaEchipe = GetEchipe();
            foreach (var echipa in listaEchipe)
            {
                Echipa ech = new Echipa();
                ech.Id = echipa.Id;
                ech.Nume = echipa.Nume;
                ToateEchipele.Add(ech);
            }
            comboBox1.DataSource = ToateEchipele;
            comboBox1.DisplayMember = "Nume";
            comboBox1.ValueMember = "Id";
            
        }
        //butonul de adaugare
        private async void button2_Click(object sender, EventArgs e)
        {    //preluarea din textBox
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string data_nastere = dateTimePicker1.Text;
            string email = textBox4.Text;
            string nr_telefon = textBox8.Text;
            string cnp = textBox5.Text;
            string SerieNrBuletin = textBox6.Text;
            string parola = textBox10.Text;
            string data_angajarii = dateTimePicker2.Text;
            string managerid = comboBox2.Text;
            string salariu = textBox3.Text;
            string zileconcediuramase = textBox7.Text;
            string idechipa = comboBox1.Text;
            bool isError = false;

            /*  //validari
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
              if (email == "")
              {
                  errorProvider1.SetError(textBox4, "Trebuie completat emailul");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(textBox4, "");

              }
              if (cnp == "")
              {
                  errorProvider1.SetError(textBox5, "Trebuie completat CNP-ul");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(textBox5, "");

              }
              if (SerieNrBuletin == "")
              {
                  errorProvider1.SetError(textBox6, "Trebuie completat Seria si Numarul CI");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(textBox6, "");

              }
              if (parola == "")
              {
                  errorProvider1.SetError(textBox10, "Trebuie completata parola");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(textBox10, "");

              }
              if (DateTime.Parse(data_angajarii) <  DateTime.Parse(data_nastere))
              {
                  errorProvider1.SetError(dateTimePicker2, "Data angajarii este invalida");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(dateTimePicker2, "");
              }

              try
              {
                  Int32.Parse(salariu);
                  errorProvider2.SetError(textBox3, "");

              }
              catch {

                  errorProvider2.SetError(textBox3, "Salariul este doar numeric");
                  isError = true;

              }
              try
              {
                  Int32.Parse(nr_telefon);
                  errorProvider2.SetError(textBox8, "");

              }
              catch
              {

                  errorProvider2.SetError(textBox8, "Introduceti un numar de telefon valid");
                  isError = true;

              }
              try
              {
                  Int32.Parse(zileconcediuramase);
                  errorProvider2.SetError(textBox7, "");

              }
              catch
              {

                  errorProvider2.SetError(textBox7, "Introduceti un numar de zile valid");
                  isError = true;

              }
              if (DateTime.Parse(data_nastere) > DateTime.Now)
              {
                  errorProvider1.SetError(dateTimePicker1, "Trebuie completata data nasterii valida");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(dateTimePicker1, "");
              }
              if (DateTime.Parse(data_angajarii) > DateTime.Now)
              {
                  errorProvider1.SetError(dateTimePicker2, "Trebuie completata data angajarii valida");
                  isError = true;
              }
              else
              {
                  errorProvider1.SetError(dateTimePicker2, "");
              }
              if(nume.Length >150)
              {
                  errorProvider1.SetError(textBox1, "Ati introdus prea multe caractere");
                  isError = true;

              }
              if (nume.Length < 2)
              {
                  errorProvider1.SetError(textBox1, "Ati introdus prea putine caractere");
                  isError = true;

              }
              if(prenume.Length > 100)
              {
                  errorProvider1.SetError(textBox2, "Ati introdus prea multe caractere");
                  isError = true;
              }
              if (prenume.Length < 2)
              {
                  errorProvider1.SetError(textBox2, "Ati introdus prea putine caractere");
                  isError = true;
              }
              if(nr_telefon.Length > 20)
              {
                  errorProvider1.SetError(textBox8, "Ati introdus prea multe caractere");
                  isError = true;
              }
              if (nr_telefon.Length <10 )
              {
                  errorProvider1.SetError(textBox8, "Ati introdus prea putine caractere");
                  isError = true;
              }
              if(email.Length < 4)
              {
                  errorProvider1.SetError(textBox4, "Ati introdus prea putine caractere");
                  isError=true;   
              }
              if (email.Length > 100)
              {
                  errorProvider1.SetError(textBox4, "Ati introdus prea multe caractere");
                  isError = true;
              }
              if(cnp.Length <13)
              {
                  errorProvider1.SetError(textBox5, "Ati introdus prea putine caractere");
                  isError = true;
              }
              if (cnp.Length > 13)
              {
                  errorProvider1.SetError(textBox5, "Ati introdus prea mare caractere");
                  isError = true;
              }
              if(SerieNrBuletin.Length >6)
              {
                  errorProvider1.SetError(textBox6, "Ati introdus prea putine caractere");
                  isError |= true;    
              }
               if(SerieNrBuletin.Length >6)
              {
                  errorProvider1.SetError(textBox6, "Ati introdus prea putine caractere");
                  isError |= true;    
              }





          }

          private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
          {
              comboBox2.ValueMember = "Id";
          } */
        }


    }
}
