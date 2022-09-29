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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Adaugare_Date_Suplimetare_Angajat : Form
    {
        public Adaugare_Date_Suplimetare_Angajat()
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
            var url = String.Format("http://localhost:5107/Angajat/GetDateAngajat/{0}", email);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        List<Angajat> listaManageri = new List<Angajat>();
        List<int> listaIduri = new List<int>();
        private void Angajare_Load(object sender, EventArgs e)
        {
            //comboBox pt toti Managerii mai putin pt cel logat

            List<XD.Models.Angajat> listaAngajati = GetManageri();
            foreach (var angajat in listaAngajati)
            {
                Angajat a = new Angajat();
                a.id = angajat.Id;
                a.Nume = angajat.Nume;
                a.Prenume = angajat.Prenume;
                listaManageri.Add(a);
                listaIduri.Add(a.id);

            }

            

            /*
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" SELECT * FROM Angajat WHERE ManagerId is null AND Email<>'" + Globals.EmailUserViewed + "'");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var listamanageri = new Angajat();
                            var x = dr.GetValue(1);
                            var y = dr.GetValue(2);
                            var z = dr.GetValue(0);

                            listamanageri.id = (int)z;
                            listamanageri.Nume = x.ToString();
                            listamanageri.Prenume = y.ToString();

                            listaManager.Add(listamanageri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();
                    conn.Close();


                    
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }*/
                    comboBox1.DataSource = listaManageri;
                    comboBox1.DisplayMember = "NumeComplet";
                    comboBox1.ValueMember = "id";
                    EroareSalariu.Text = "";
                    EroareAdaugare.Text = "";

        }

        private async Task adaugareSuplimentaraNew( decimal Salariu, int ManagerId )
        {
            HttpClient httpClient = new HttpClient();


            XD.Models.Angajat a = GetAngajat(Globals.EmailUserAprobare);
            a.DataAngajarii = dateTimePicker1.Value.Date;
            //a.NumarZileConceiduRamase = Int32.Parse(NumarZileConcediu);
          

            a.Salariu = Salariu;
            a.ManagerId = ManagerId;
            a.EsteAngajatCuActeInRegula = true;
           
           
            string jsonString = JsonConvert.SerializeObject(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/UpdateAprobareAngajare", stringContent);
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;
        }
       private  async void button1_Click(object sender, EventArgs e)
        {


            string DataAngajarii = dateTimePicker1.Text;
            //string NumarZileConcediu = textBox1.Text;
            string Salariu1 = textBox2.Text;
            int ManagerId1 = listaIduri[comboBox1.SelectedIndex];
            bool isError1 = false;

            //try
            //{
            //    Int32.Parse(NumarZileConcediu);
            //    errorProvider1.SetError(textBox1, "");
            //}

            /*  try
              {
                  Int32.Parse(Salariu);
                  errorProvider1.SetError(textBox2, "");

              }
              catch
              {

                  errorProvider1.SetError(textBox2, "Introduceti un salariu  numeric");
                  isError = true;

              } */


            //string data_angajarii_formatata = DataAngajarii.Substring(DataAngajarii.IndexOf(',') + 2, DataAngajarii.Length - 2 - DataAngajarii.IndexOf(','));

            if (!isError1)
            {
               
                //salariu
                const string reSalariu = "^[0-9]*$";
                if (!Regex.Match(Salariu1.ToString(), reSalariu, RegexOptions.IgnoreCase).Success)
                {
                    isError1 = true;
                    EroareSalariu.Text = "* Salariul este doar numeric";
                }
            }

            if (!isError1)
            {
                await adaugareSuplimentaraNew(decimal.Parse(Salariu1), ManagerId1);
                Aprobare_Angajare form = new Aprobare_Angajare();
                this.Hide();
                this.Close();
                form.ShowDialog();
            }
            else
            {
                EroareAdaugare.Text = " Eroare de adaugare";
            }
          

             

            
            /*
            try
            { //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" UPDATE Angajat  SET DataAngajarii ='" +data_angajarii_formatata  + "',ManagerId ='" + comboBox1.SelectedValue.ToString() + "' ,NumarZileConceiduRamase = '" + NumarZileConcediu  + "',Salariu = '" + Salariu + "', EsteAngajatCuActeInRegula = '" +  1 + "' WHERE Email = '" + Globals.EmailAngajatCuActeNeinregula + "'  ");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    Globals.executeNonQuery(query);

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                   

               
                    conn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }*/

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
