﻿using System;
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
            bool isError = false;
            

            if(nume == "")
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
            //data nastere in viitor
            if (DateTime.Parse(data_nastere) > new DateTime())
            {
                errorProvider1.SetError(dateTimePicker1, "Trebuie completata data nasterii valida");
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
                errorProvider1.SetError(textBox6, "Trebuie completat CNP-ul");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
            if (parola == "")
            {
                errorProvider1.SetError(textBox7, "Trebuie completata parola");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
            if (conf_parola == "")
            {
                errorProvider1.SetError(textBox8, "Trebuie completata confirmarea parolei");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }



            if (!isError)
            {

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
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Formular_Inregistrare_Load(object sender, EventArgs e)
        {

        }
    }
}
