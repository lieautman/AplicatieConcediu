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
            string parola = textBox7.Text;
            string conf_parola = textBox8.Text;




            string sqlText = "insert into Angajat(nume\r\n,prenume\r\n,dataNasterii\r\n,email\r\n,parola\r\n,dataAngajare\r\n,cnp\r\n,serie\r\n,[no]\r\n,nrTelefon\r\n,poza\r\n,esteAdmin\r\n,managerId)" +
                "values(\r\n'"+nume+ "','"+prenume+ "','11/11/2011''"+ email +"','" + parola + "','11/11/2011','"+cnp+"','rk','123456','1234567890',1,0,null)";
            //
            Globals.executeNonQuery(sqlText);


//            string sqlText1 = "SELECT TOP (1000) [id]\r\n      ,[nume]\r\n      ,[prenume]\r\n      ,[email]\r\n      ,[parola]\r\n      ,[dataAngajare]\r\n      ,[dataNasterii]\r\n      ,[cnp]\r\n      ,[serie]\r\n      ,[no]\r\n      ,[nrTelefon]\r\n      ,[poza]\r\n      ,[esteAdmin]\r\n      ,[managerId]\r\n  FROM [GameOfThrones].[dbo].[Angajat]";
  //          SqlDataReader a=  Globals.executeQuery(sqlText1);



        }
    }
}
