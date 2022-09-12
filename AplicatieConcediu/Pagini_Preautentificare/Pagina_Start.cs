using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieConcediu
{
    public partial class Pagina_start : Form
    {
        public Pagina_start()
        {
            InitializeComponent();
        }

        //buton de inregistrare
        private void buttonInregistrare_Click(object sender, EventArgs e)
        {
            Form inregistrare = new Formular_Inregistrare();
            this.Hide();
            inregistrare.ShowDialog();
            this.Show();
        }

        //buton de autentificare
        private void buttonAutentificare_Click(object sender, EventArgs e)
        {
            Form autentificare = new Formular_Autentificare();
            this.Hide();
            autentificare.ShowDialog();
            this.Show();

        }

        //buton de inchidere
        private void buttonInchidere_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
