using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace AplicatieConcediu
{
    public partial class Formular_Inregistrare : Form
    {
        string connString = Globals.ConnString;
            //ConfigurationManager.ConnectionStrings["DatabaseString"].ConnectionString
        public Formular_Inregistrare()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connString);
            
            connection.Open();
            string sqlText = "insert into Angajat(nume\r\n,prenume\r\n,email\r\n,parola\r\n,dataAngajare\r\n,dataNasterii\r\n,cnp\r\n,serie\r\n,[no]\r\n,nrTelefon\r\n,poza\r\n,esteAdmin\r\n,managerId) values(\r\n'B','B','B','B','111111','111111','1234567890123','rk','123456','1234567890',1,0,null)";

            SqlCommand command = new SqlCommand(sqlText, connection);
            command.ExecuteNonQuery();


            connection.Close();


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string data_nastere = textBox3.Text;
            string email = textBox4.Text;
            string nr_telefon = textBox5.Text;
            string cnp = textBox6.Text;
            string parola = textBox7.Text;
            string conf_parola = textBox8.Text;


        }
    }
}
