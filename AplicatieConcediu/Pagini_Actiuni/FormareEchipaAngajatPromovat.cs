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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class FormareEchipaAngajatPromovat : Form
    {
        private List<Angajat> listaAngajati = new List<Angajat>();
        public FormareEchipaAngajatPromovat()
        {
            InitializeComponent();
        }

        private void FormareEchipaAngajatPromovat_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Nume, Prenume from Angajat where Email = '"+Globals.EmailManager+"'", out conn1);
            string numesiprenume = "";
            while (reader1.Read())
            {
                numesiprenume += reader1["Nume"];
                numesiprenume += " ";
                numesiprenume += reader1["Prenume"];
            }
            reader1.Close();
            conn1.Close();
            label3.Text = numesiprenume;


            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("Select * from Angajat where ManagerId is not null ", out conn);
            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                Angajat angajat = new Angajat(10,nume, prenume, email,"","",new DateTime(),new DateTime(),"","","","",0,0,0,0,0);
                listaAngajati.Add(angajat);
            }

            dataGridView1.DataSource = listaAngajati;

            conn.Close();
        }
    }
}
