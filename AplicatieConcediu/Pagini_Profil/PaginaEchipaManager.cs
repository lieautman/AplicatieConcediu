using AplicatieConcediu.DB_Classess;
using AplicatieConcediu.Pagini_Actiuni;
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
using System.IO;

namespace AplicatieConcediu.Pagini_Profil
{
    public partial class PaginaEchipaManager : Form
    {
        private List<VizualizareEchipaManager> lista=new List<VizualizareEchipaManager>();
        public PaginaEchipaManager()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormareEchipaAngajatPromovat membruNou = new FormareEchipaAngajatPromovat();
            this.Hide();
            membruNou.ShowDialog();
            this.Show();
        }

        private void PaginaEchipaManager_Load(object sender, EventArgs e)
        {


            SqlConnection conn1 = new SqlConnection();
            //SqlDataReader reader1 = Globals.executeQuery("Select Nume, Prenume, Id from Angajat where Email = '" + Globals.EmailManager + "'", out conn1);
            SqlDataReader reader1 = null;
            string numesiprenume = "";
            while (reader1.Read())
            {
                numesiprenume += reader1["Nume"];
                numesiprenume += " ";
                numesiprenume += reader1["Prenume"];
                Globals.IdManager = (int)reader1["Id"];
            }
            reader1.Close();
            conn1.Close();
            label1.Text = numesiprenume;


            SqlConnection conn = new SqlConnection();
            // SqlDataReader reader = Globals.executeQuery("Select Nume, Prenume, IdEchipa, ManagerId from Angajat where ManagerId='"+Globals.IdManager+"' and IdEchipa= '" + Globals.IdEchipa + "'", out conn);
            SqlDataReader reader = null;
            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                int managerId = (int)reader["ManagerId"];
                int idEchipa = (int)reader["Idechipa"];


                VizualizareEchipaManager angajat = new VizualizareEchipaManager(nume, prenume,idEchipa, managerId);
                lista.Add(angajat);
            }

            dataGridView1.DataSource = lista;

            conn.Close();

            //poza echipei 
            byte[] poza = { };
            bool isOk = true;
            //string query2 = "SELECT Poza FROM Angajat WHERE IdEchipa ='" + Globals.IdEchipa + "'";
            string query2 = null;
            SqlConnection connection2;
            //SqlDataReader reader2 = Globals.executeQuery(query2, out connection2);
            SqlDataReader reader2 = null;

            while (reader2.Read())
            {
                if (reader2["Poza"] != DBNull.Value)
                    poza = (byte[])reader2["Poza"];
                else
                    isOk = false;

            }
            reader2.Close();
            //connection2.Close();
            if (isOk == true)
                pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));
        }
    }
}
