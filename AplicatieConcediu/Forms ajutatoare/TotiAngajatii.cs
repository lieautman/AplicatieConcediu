using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using System.Data.SqlClient;


namespace AplicatieConcediu
{
    public partial class TotiAngajatii : Form

    {
        private List<AngajatiLista> listaAngajati = new List<AngajatiLista>();
        public TotiAngajatii()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TotiAngajatii_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("Select Nume, Prenume from Angajat", out conn);


            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];


                AngajatiLista angajat = new AngajatiLista(nume, prenume);


                listaAngajati.Add(angajat);
            }
            reader.Close();

            dataGridView1.DataSource = listaAngajati;

            conn.Close();
        }
    }
}
