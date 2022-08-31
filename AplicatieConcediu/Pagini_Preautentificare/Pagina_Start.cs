﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form inregistrare = new Formular_Inregistrare();
            this.Hide();
            inregistrare.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form autentificare = new Formular_Autentificare();
            this.Hide();
            autentificare.ShowDialog();
            this.Show();

        }

        private void Pagina_start_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}