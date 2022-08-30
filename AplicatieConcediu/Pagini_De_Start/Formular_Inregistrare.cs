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
        public Formular_Inregistrare()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string data_nastere = dateTimePicker1.Text;
            string email = textBox4.Text;
            string nr_telefon = textBox5.Text;
            string cnp = textBox6.Text;
            string SerieNrBuletin = textBox3.Text;
            string parola = textBox7.Text;
            string conf_parola = textBox8.Text;

            if (parola == conf_parola)
            {

                //formatare data
                string data_nastere_formatata = data_nastere.Substring(data_nastere.IndexOf(',') + 2, data_nastere.Length - 2 - data_nastere.IndexOf(','));


                string sqlText = "insert into Angajat(Nume, Prenume, Email,Parola, DataAngajarii, DataNasterii, CNP, SeriaNumarBuletin,Numartelefon,Poza,EsteAdmin,ManagerId,Salariu, EsteAngajatCuActeInRegula)" +
                    "values('" + nume + "','" + prenume + "','" + email + "','" + parola + "',null ,'" + data_nastere_formatata + "','" + cnp + "','" + SerieNrBuletin + "','" + nr_telefon + "',null,0,null,null,0)";

                Globals.executeNonQuery(sqlText);
                this.Close();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Parola nu corespunde");
            }





            //            string sqlText1 = "SELECT TOP (1000) [id]\r\n      ,[nume]\r\n      ,[prenume]\r\n      ,[email]\r\n      ,[parola]\r\n      ,[dataAngajare]\r\n      ,[dataNasterii]\r\n      ,[cnp]\r\n      ,[serie]\r\n      ,[no]\r\n      ,[nrTelefon]\r\n      ,[poza]\r\n      ,[esteAdmin]\r\n      ,[managerId]\r\n  FROM [GameOfThrones].[dbo].[Angajat]";
            //          SqlDataReader a=  Globals.executeQuery(sqlText1);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
