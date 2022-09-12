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

            try
            {
                var response = await httpClient.PostAsync("http://localhost:5107/Angajat/AngajatAutentificare", stringContent);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent content = response.Content;
                    Task<string> result = content.ReadAsStringAsync();
                    string res = result.Result;

                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };

                    XD.Models.Angajat b = JsonConvert.DeserializeObject<XD.Models.Angajat>(res, jsonSettings);

                    //schimbare date globale despre utilizator
                    Globals.EmailUserActual = b.Email;
                    Globals.AngajatLogatInAplicatie = b;
                    Globals.IdUserActual1 = b.Id;
                    Globals.IsAdmin = Convert.ToBoolean(b.EsteAdmin);
                    Globals.IdManager = b.ManagerId;
                    if (b.ManagerId == null)
                        Globals.IsManager = true;
                    else
                        Globals.IsManager = false;

                    if (textBoxNume.Text != b.Email)
                    {
                        labelEroareEmail.Text = "* Nume de utilizator gresit";
                        isError = true;
                    }
                    if (textBoxParola.Text != b.Parola)
                    {
                        labelEroareParola.Text = "* Parola gresita";
                        isError = true;
                    }
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    labelEroareEmail.Text = "* Nume de utilizator gresit";
                    isError = true;
                    labelEroareParola.Text = "* Parola gresita";
                    isError = true;
                }
                else
                {
                    labelEroareEmail.Text = "";
                    labelEroareParola.Text = "";
                    labelEroareServer.Text = "A aparut o eroare de server!";
                    isError = true;
                }
            }
            catch
            {
                labelEroareEmail.Text = "";
                labelEroareParola.Text = "";
                labelEroareServer.Text = "A aparut o eroare de server!";
                isError = true;
            }
        }

        //buton de autentificare
        private async void buttonAutentificare_Click(object sender, EventArgs e)
        {
            //resetare erori
            isError = false;


            //preluare valori din textbox-uri
            string userEmail = textBoxNume.Text;
            string userParola = textBoxParola.Text;

            //verificare campuri goale
            if (!isError)
            {
                if(textBoxNume.Text == "")
                {
                    labelEroareEmail.Text = "* Introduceti numele de utilizator";
                    isError = true;
                }
                if (textBoxParola.Text == "")
                {
                    labelEroareParola.Text = "* Introduceti parola";
                    isError = true;
                }
            }


            await autentificareNew(userEmail, userParola);

            if (!isError)
            {
                

                Form autentificare2fact = new Formular_Autentificare_2factori();
                this.Hide();
                autentificare2fact.ShowDialog();
                this.Show();
            }
        }

        //buton de inchidere
        private void buttonInchidere_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //golire label-uri la load
        private void Formular_Autentificare_Load(object sender, EventArgs e)
        {
            labelEroareEmail.Text = "";
            labelEroareParola.Text = "";
            labelEroareServer.Text = "";
        }
    }
}
