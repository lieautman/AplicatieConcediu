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
    public partial class PaginaCuTotiAngajatii : Form
    {
        public PaginaCuTotiAngajatii()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();


        }


        private void PaginaCuTotiAngajatii_Load(object sender, EventArgs e)
        {

        }

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
    }
}
