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

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void PaginaCuTotiAngajatii_Load(object sender, EventArgs e)
        {

        }
    }
}
