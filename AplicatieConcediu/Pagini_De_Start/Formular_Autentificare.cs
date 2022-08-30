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


namespace AplicatieConcediu
{
    public partial class Formular_Autentificare : Form
    {
        public Formular_Autentificare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verifica daca valorile email si parola sunt in baza de date si daca sunt corecte
            //de facut!
            string userEmail = textBox1.Text; // de preluat din formular si validat 
            string userParola = textBox2.Text;

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

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var Id = dr.GetInt32(0);
                            var Nume = dr.GetString(1);
                            var Prenume = dr.GetString(2);
                            var Email = dr.GetString(3);
                            var Parola = dr.GetString(4);
                            var DataAngajarii = dr.GetString(5);
                            var DataNasterii = dr.GetString(6);
                            var CNP = dr.GetString(7);
                            var SeriaNumarBuletin = dr.GetString(8);
                            var Numartelefon = dr.GetString(9);
                            var Poza = dr.GetString(10);
                            var EsteAdmin = dr.GetString(11);
                            var ManagerId = dr.GetString(12);
                            var Salariu = dr.GetString(13);
                            var EsteAngajatCuActeInRegula = dr.GetString(14);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
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
                Console.WriteLine("Exception: " + ex.Message);
            }

        //de trimis email cu codul de validare (de 6 cifre)
        /*int nrTrimis = 123454;
            string stringTrimis = nrTrimis.ToString();


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            smtp.Send(mail);
        */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formular_Autentificare_Load(object sender, EventArgs e)
        {

        }

    }
}
