﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AplicatieConcediu.Pagini_Concedii;

namespace AplicatieConcediu
{
    public partial class Pagina_Profil_Angajat : Form
    {
        public Pagina_Profil_Angajat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form concedii = new Pagina_ConcediileMele();
            this.Hide();
            concedii.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pagina_Profil_Angajat_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Angajat WHERE Email ='"+Globals.EmailUserActual+"'";
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery(query,out connection);


            while(reader.Read())
            {
                string nume = (string)reader["Nume"];
                label12.Text = nume;
                string prenume = (string)reader["Prenume"];
                label13.Text = prenume;


                if (reader["esteAdmin"] is true)
                {
                    label14.Text = "Administrator";
                }
                else if (reader["ManagerId"] != null)
                {
                    label14.Text = "Manager";
                }
                else
                    label14.Text = "Angajat";


                if (reader["DataAngajarii"]!=
                    System.DBNull.Value)
                {
                    string data_angajare = (string)reader["DataAngajarii"];
                    label15.Text = data_angajare;
                }
                string email = (string)reader["Email"];
                label16.Text = email;
                string telefon = (string)reader["Numartelefon"];
                label17.Text = telefon;
                DateTime data_nastere = (DateTime)reader["DataNasterii"];
                label18.Text = data_nastere.ToString().Substring(0,9);
                string cnp = (string)reader["CNP"];
                label19.Text = cnp;
                string serie_numar = (string)reader["SeriaNumarBuletin"];
                label20.Text = serie_numar.Substring(0, 2);
                label21.Text = serie_numar.Substring(2);
                string salariu = reader["Salariu"].ToString();
                label22.Text = salariu;

            }

            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form creareconcediu = new Pagina_CreareConcediu();
            this.Hide();
            creareconcediu.ShowDialog();
            this.Show();
        }
    }
}
