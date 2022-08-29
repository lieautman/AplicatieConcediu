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
    public partial class ProfilAngajat : Form
    {
        public ProfilAngajat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form concedii = new ConcediileMele();
            concedii.ShowDialog();

        }
    }
}
