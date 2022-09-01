using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieConcediu.Pagini_Profil
{
    public partial class PaginaCuTotateEchipele : Form
    {
        public PaginaCuTotateEchipele()
        {
            InitializeComponent();
        }



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

        }
    }
}
