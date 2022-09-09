﻿using AplicatieConcediu.DB_Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Promovare_Angajat : Form
    {

        private List<JoinAngajatiiConcedii> listaAngajati = new List<JoinAngajatiiConcedii>();
        private List<AfisareAngajati> listaAngajati2 = new List<AfisareAngajati>();    


        public Promovare_Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public List<XD.Models.Angajat> PromovareAngajati()
        {
            var url = "http://localhost:5107/api/PromovareAngajat/PromovareAngajat";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Angajat> list = new List<XD.Models.Angajat>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.Angajat>>(result, settings);
            }
            return list;
        }




        private void Promovare_Angajat_Load(object sender, EventArgs e)
        {

            List<XD.Models.Angajat> lista = PromovareAngajati();


            foreach (XD.Models.Angajat angajat in lista)
            {
                AfisareAngajati afisareAngajati = new AfisareAngajati();
                afisareAngajati.Nume = angajat.Nume;
                afisareAngajati.Prenume = angajat.Prenume;
                afisareAngajati.Email = angajat.Email;
                afisareAngajati.DataNasterii = angajat.DataNasterii;
                afisareAngajati.Numartelefon = angajat.Numartelefon;
                afisareAngajati.NumeEchipa = angajat.IdEchipa.ToString();
                listaAngajati2.Add(afisareAngajati);
            }

            dataGridView1.DataSource = listaAngajati2;

          

            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Actiuni";
            buton.HeaderText = "Actiuni";
            buton.Text = "Promoveaza";
            buton.Tag = (Action<AfisareAngajati>)ClickHandler;
            buton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(buton);
            dataGridView1.CellContentClick += Buton_CellContentClick;

        }

        private void Buton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
            {
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                var clickHandler = (Action<AfisareAngajati>)grid.Columns[e.ColumnIndex].Tag;
                var person = (AfisareAngajati)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(person);
            }
        }
        private void ClickHandler(AfisareAngajati a)
        {
            Globals.EmailManager = a.Email;
            FormareEchipaAngajatPromovat form = new FormareEchipaAngajatPromovat();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)


        {






        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
