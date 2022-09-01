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
            //daca am mai multe instante de acest formular, il inchid. daca nu, il las deschis
            if (Application.OpenForms.OfType<PaginaCuTotateEchipele>().Count() > 1)
            {
                this.Close();
                TotiAngajatii.ShowDialog();
            }
            else
            {
                this.Hide();
                TotiAngajatii.ShowDialog();
                this.Show();
            }
        }
        //buton vizualizare profil
        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            //daca am mai multe instante de acest formular, il inchid. daca nu, il las deschis
            if (Application.OpenForms.OfType<PaginaCuTotateEchipele>().Count() > 1)
            {
                this.Close();
                form.ShowDialog();
            }
            else
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }
        //buton inapoi
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaginaCuTotateEchipele_Load(object sender, EventArgs e)
        {
            byte[] poza = { };
           List<bool> isOk = new List<bool>();
            string query1 = "SELECT Poza FROM Echipa ";
            SqlConnection connection1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery(query1, out connection1);

            while (reader1.Read())
            {
                if (reader1["Poza"] != DBNull.Value)
                {
                    poza = (byte[])reader1["Poza"];
                    PozaLista.Add(poza);
                    isOk.Add(true);
                }
                else
                    isOk.Add(false);

            }
            reader1.Close();
            connection1.Close();
            List<PictureBox> pictureBoxList = new List<PictureBox>();
            pictureBoxList.Add(pictureBox1);
            pictureBoxList.Add(pictureBox2);
            pictureBoxList.Add(pictureBox3);
            pictureBoxList.Add(pictureBox4);
            pictureBoxList.Add(pictureBox5);



            for (int i = 0; i < isOk.Count; i++)
            {
                if (isOk[i] == true)
                    pictureBoxList[i].Image = System.Drawing.Image.FromStream(new MemoryStream(PozaLista[i]));

            }
        }
    }
}
