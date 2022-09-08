using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using SqlDataReader = System.Data.SqlClient.SqlDataReader;
using System.Reflection.Emit;
using AplicatieConcediu.Pagini_De_Start;
using System.Net.Http;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.Json;
using Newtonsoft.Json;

namespace AplicatieConcediu
{
    public partial class Formular_Autentificare : Form
    {
        public Formular_Autentificare()
        {
            InitializeComponent();
        }

        public bool isError = false;

        //metoda legacy de autentificare
        private void autentificateLegacy(string userEmail, string userParola, out bool utilizatorExistent, out bool parolaCorecta)
        {



            //verificare daca a lasat campurile goale
            //if (textBox1.Text == "")
            //{
            //errorProvider1.SetError(textBox1, "Introduceti numele de utilizator");
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox1, "");
            //    utilizatorNull = true;
            //}
            //if (textBox2.Text == "")
            //{
            //    errorProvider2.SetError(textBox2, "Introduceti parola");
            //}
            //else
            //{
            //    errorProvider1.SetError(textBox2, "");
            //    parolaNull = true;
            //}

            utilizatorExistent = false;
            parolaCorecta = false;
            //  conectare la baza de date pentru a vedea daca valorile sunt ok
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {

                    //retrieve the SQL Server instance version
                    string query = string.Format("SELECT * FROM Angajat WHERE Email='" + userEmail + "' AND Parola='" + userParola + "'");
                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var Id = dr.GetInt32(0);
                            var Nume = dr.GetString(1);
                            var Prenume = dr.GetString(2);
                            // var IsAdmin = dr.GetString(11);

                            if (dr["Email"] == DBNull.Value)
                            {

                                var Email = "";
                            }
                            else
                            {
                                var Email = dr.GetString(3);
                            }


                            if (dr["EsteAdmin"] == DBNull.Value)
                            {
                                Globals.IsAdmin = false;
                            }
                            else
                            {
                                Globals.IsAdmin = Convert.ToBoolean(dr["EsteAdmin"]);
                            }

                            if (dr["Parola"] == DBNull.Value)
                            {

                                var Parola = "";
                            }
                            else
                            {
                                var Parola = dr.GetString(4);
                            }


                            if (dr["DataAngajarii"] == DBNull.Value)
                            {
                                var DataAngajarii = "";
                            }
                            else
                            {
                                var DataAngajarii = dr.GetString(5);
                            }

                            var DataNasterii = dr.GetDateTime(6);
                            var CNP = dr.GetString(7);

                            if (dr["SeriaNumarBuletin"] == DBNull.Value)
                            {
                                var SeriaNumarBuletin = "";
                            }
                            else
                            {
                                var SeriaNumarBuletin = dr.GetString(8);
                            }

                            if (dr["Numartelefon"] == DBNull.Value)
                            {
                                var Numartelefon = "";
                            }
                            else
                            {
                                var Numartelefon = dr.GetString(9);
                            }

                            if (dr["Poza"] == DBNull.Value)
                            {
                                var Poza = "";
                            }
                            else
                            {
                                var Poza = dr.GetValue(10);
                            }

                            /* if (dr["EsteAdmin"] == DBNull.Value)
                             {
                                 var EsteAdmin = "";
                             }
                             else
                             {
                                 var EsteAdmin = dr.GetValue(11);
                             }*/

                            if (dr["ManagerId"] == DBNull.Value)
                            {
                                var ManagerId = "";
                            }
                            else
                            {
                                var ManagerId = dr.GetInt32(12);
                            }

                            if (dr["Salariu"] == DBNull.Value)
                            {
                                var Salariu = "";
                            }
                            else
                            {
                                var Salariu = dr.GetValue(13);
                            }

                            if (dr["EsteAngajatCuActeInRegula"] == DBNull.Value)
                            {
                                var EsteAngajatCuActeInRegula = "";
                            }
                            else
                            {
                                var EsteAngajatCuActeInRegula = dr.GetValue(14);
                            }




                            if (textBox1.Text != dr["Email"].ToString())
                            {
                                errorProvider1.SetError(textBox1, "Nume de utilizator gresit");

                            }
                            else
                            {
                                errorProvider1.SetError(textBox1, "");
                                utilizatorExistent = true;

                            }


                            if (textBox2.Text != dr["Parola"].ToString())
                            {
                                errorProvider1.SetError(textBox2, "Parola gresita");

                            }
                            else
                            {
                                errorProvider1.SetError(textBox2, "");
                                parolaCorecta = true;

                            }

                        }
                    }

                    //close data reader
                    dr.Close();
                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                errorProvider1.SetError(button1, "Exception: " + ex.Message);
            }
        }
        //metoda noua de autentificare
        private async Task autentificareNew(string email, string parola)
        {
            HttpClient httpClient = new HttpClient();
            XD.Models.Angajat a = new XD.Models.Angajat();

            a.Email = email;
            a.Parola = parola;
            a.Nume = "";
            a.Prenume = "";
            a.Cnp = "";

            string jsonString = System.Text.Json.JsonSerializer.Serialize<XD.Models.Angajat>(a);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/Angajat/AngajatAutentificare", stringContent);


            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            XD.Models.Angajat b = JsonConvert.DeserializeObject<XD.Models.Angajat>(res, jsonSettings);

            Globals.IsAdmin = Convert.ToBoolean(b.EsteAdmin);
            if (b.ManagerId == null)
                Globals.IsManager = true;
            else
                Globals.IsManager = false;
            if (textBox1.Text != b.Email)
            {
                labelEroareEmail.Text  = "* Nume de utilizator gresit";
                isError = true;
            }
            if (textBox2.Text != b.Parola)
            {
                labelEroareParola.Text = "* Parola gresita";
                isError = true;


            }
        }

        //buton de autentificare
        private async void button1_Click(object sender, EventArgs e)
        {
            //resetare erori
            isError = false;


            //preluare valori din textbox-uri
            string userEmail = textBox1.Text;
            string userParola = textBox2.Text;

            //verificare campuri goale
            if (!isError)
            {
                if(textBox1.Text == "")
                {
                    labelEroareEmail.Text = "* Introduceti numele de utilizator";
                    isError = true;
                }
                if (textBox2.Text == "")
                {
                    labelEroareParola.Text = "* Introduceti parola";
                    isError = true;
                }
            }


            //autentificateLegacy(userEmail, userParola, out utilizatorExistent, out parolaCorecta);
            await autentificareNew(userEmail, userParola);

            if (!isError)
            {
                
                Globals.EmailUserActual = userEmail;

                Form autentificare2fact = new Formular_Autentificare_2factori();
                this.Hide();
                autentificare2fact.ShowDialog();
                this.Show();
            }
        }

        //buton de inchidere
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //golire label-uri la load
        private void Formular_Autentificare_Load(object sender, EventArgs e)
        {
            labelEroareEmail.Text = "";
            labelEroareParola.Text = "";
        }
    }
}
