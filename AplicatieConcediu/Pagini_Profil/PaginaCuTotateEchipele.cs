using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AplicatieConcediu.Pagini_Profil
{
     
    public partial class PaginaCuTotateEchipele : Form
    {
        public PaginaCuTotateEchipele()
        {
            InitializeComponent();
        }
        public List<byte[]> PozaLista = new List<byte[]>();
        

        //trebuie create automat din cod si de acolo trebuie incarcate pozele si tot
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Echipe = new Echipe();
            this.Hide();
            Echipe.ShowDialog();
            this.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Echipe = new Echipe();
            this.Hide();
            Echipe.ShowDialog();
            this.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Echipe = new Echipe();
            this.Hide();
            Echipe.ShowDialog();
            this.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Echipe = new Echipe();
            this.Hide();
            Echipe.ShowDialog();
            this.Show();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form Echipe = new Echipe();
            this.Hide();
            Echipe.ShowDialog();
            this.Show();
        }


        //buton vizualizare toti angajatii
        private void button1_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            this.Close();
            TotiAngajatii.ShowDialog();
        }
        //buton vizualizare profil
        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            this.Hide();
            this.Close();
            form.ShowDialog();
        }
        //buton inapoi
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaginaCuTotateEchipele_Load(object sender, EventArgs e)
        {
            byte[] poza = { };
            bool isOk = true;
            string query1 = "SELECT Poza FROM Echipa ";
            SqlConnection connection1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery(query1, out connection1);

            while (reader1.Read())
            {
                if (reader1["Poza"] != DBNull.Value)
                    poza = (byte[])reader1["Poza"];
                 
                else
                    isOk = false;

            }
            reader1.Close();
            connection1.Close();
            if (isOk == true)
                pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));
            

        }
    }
}
