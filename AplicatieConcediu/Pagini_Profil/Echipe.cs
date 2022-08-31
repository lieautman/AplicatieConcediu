using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;

namespace AplicatieConcediu.Pagini_Profil
{
    public partial class Echipe : Form
    {
        private List<AngajatiLista> listaAngajati = new List<AngajatiLista>();
        public Echipe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Echipe_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select Nume, Prenume from Angajat", out conn);

            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                int managerId = (int)reader["ManagerId"];
                int echipaId = (int)reader["idEchipa"];
                



                AngajatiLista angajat = new AngajatiLista(nume, prenume, managerId, echipaId);


                listaAngajati.Add(angajat);
            }
            reader.Close();

            conn.Close();
        }
    }
}
