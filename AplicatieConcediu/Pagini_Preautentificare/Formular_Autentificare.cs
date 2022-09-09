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

            Globals.IdUserActual1 = b.Id;
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
