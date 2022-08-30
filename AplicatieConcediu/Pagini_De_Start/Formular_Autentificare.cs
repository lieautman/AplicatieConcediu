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
using Microsoft.Data.SqlClient;


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
            //preluare email si parola
            string email = textBox1.Text;
            string parola = textBox2.Text;
            //preiau tot din bd per angajati
            string sqlCreat = "SELECT * FROM Angajat";
            SqlConnection conn;
            SqlDataReader reader=Globals.executeQuery(sqlCreat, out conn);

            try
            {
                while (reader.Read())
                {
                    
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            conn.Close();

            //vad daca pot citi
            //vad daca se gaseste



            //verifica daca valorile email si parola sunt in baza de date si daca sunt corecte
            //de facut!

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
