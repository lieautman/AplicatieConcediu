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
using AplicatieConcediu.Pagini_Actiuni;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Http;
using System.Text.Json;

namespace AplicatieConcediu.Pagini_Profil
{
     
    public partial class PaginaCuTotateEchipele : Form
    {
        public PaginaCuTotateEchipele()
        {
            InitializeComponent();
        }
        
        //trebuie create automat din cod si de acolo trebuie incarcate pozele si tot
        private void pictureBoxEchipa1_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 1;
            TotiAngajatii totiAngajatii = new TotiAngajatii();
            this.Hide();
            totiAngajatii.ShowDialog();
            this.Show();
        }
        private void pictureBoxEchipa2_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 2;
            TotiAngajatii totiAngajatii = new TotiAngajatii();
            this.Hide();
            totiAngajatii.ShowDialog();
            this.Show(); ;
        }
        private void pictureBoxEchipa3_Click(object sender, EventArgs e)
        {
            //aaa
            Globals.IdEchipa = 3;
            TotiAngajatii totiAngajatii = new TotiAngajatii();
            this.Hide();
            totiAngajatii.ShowDialog();
            this.Show();
        }
        private void pictureBoxEchipa4_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 4;
            TotiAngajatii totiAngajatii = new TotiAngajatii();
            this.Hide();
            totiAngajatii.ShowDialog();
            this.Show();
        }
        private void pictureBoxEchipa5_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 5;
            TotiAngajatii totiAngajatii = new TotiAngajatii();
            this.Hide();
            totiAngajatii.ShowDialog();
            this.Show();
        }


        //lista poze
        public List<byte[]> PozaLista = new List<byte[]>();
        //lista bool ce ne spune daca pozele sunt incarcate
        List<bool> isOk = new List<bool>();

        //incarcare poze new
        private async Task incarcarePozeNew()
        {
            //creare conexiune
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5107/Echipa/GetVizualizareEchipePoze");
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            PozaLista = JsonSerializer.Deserialize<List<byte[]>>(res);
            for (int i = 0; i < PozaLista.Count(); i++)
            {
                if (PozaLista[i] != null)
                {
                    isOk.Add(true);
                }
                else
                {
                    isOk.Add(false);
                }
            }
        }
        private async void PaginaCuTotateEchipele_Load(object sender, EventArgs e)
        {

            if (Globals.IsAdmin == true|| Globals.IdManager == null)
            {
                buttonAprobareAngajatNou.Show();
                buttonAprobareConcedii.Show();
                buttonPromovareAngajati.Show();
                buttonAdaugareAngajat.Show();

            }
            else
            {
                
                buttonAprobareAngajatNou.Hide();
                buttonAprobareConcedii.Hide();
                buttonPromovareAngajati.Hide();
                buttonAdaugareAngajat.Hide();
               
            }
            if(Globals.IdManager == null)
                buttonPromovareAngajati.Hide();


            await incarcarePozeNew();

            List<PictureBox> pictureBoxList = new List<PictureBox>();
            pictureBoxList.Add(pictureBoxEchipa1);
            pictureBoxList.Add(pictureBoxEchipa2);
            pictureBoxList.Add(pictureBoxEchipa3);
            pictureBoxList.Add(pictureBoxEchipa4);
            pictureBoxList.Add(pictureBoxEchipa5);


            for (int i = 0; i < isOk.Count; i++)
            {
                if (isOk[i] == true)
                    pictureBoxList[i].Image = System.Drawing.Image.FromStream(new MemoryStream(PozaLista[i]));
            }
        }
        int count = 1;


        //buton meniu
        private void buttonLogo_Click(object sender, EventArgs e)
        {
            count++;

           if(count %2!=0 )
            {
                buttonVizualizareAngajati.Show();
                buttonVizualizareProfil.Show();
                buttonVizualizareEchipe.Show();
                buttonDelogare.Show();
                buttonCreareCerereConcediu.Show();

                if (Globals.IsAdmin == true|| Globals.IdManager == null)
                {
                    buttonAprobareAngajatNou.Show();
                    buttonAprobareConcedii.Show();
                    buttonPromovareAngajati.Show();
                    buttonAdaugareAngajat.Show();

                }
                if (Globals.IdManager == null)
                    buttonPromovareAngajati.Hide();

            }
            else
            {
                buttonVizualizareAngajati.Hide();
                buttonVizualizareProfil.Hide();
                buttonAprobareAngajatNou.Hide();
                buttonAprobareConcedii.Hide();
                buttonPromovareAngajati.Hide();
                buttonAdaugareAngajat.Hide();
                buttonVizualizareEchipe.Hide();
                buttonDelogare.Hide();
                buttonCreareCerereConcediu.Hide();
            }
            
        }
        //buton vizualizare profil
        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        //buton vizualizare echipe
        private void buttonVizualizareEchipe_Click(object sender, EventArgs e)
        {

        }
        //buton vizualizare toti angajatii
        private void buttonVizualizareTotiAngajatii_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();
        }
        //buton vizualizare creare cerere concediu
        private void buttonCreareCerereConcediu_Click(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
        //buton aprobare concedii
        private void buttonAprobareConcedii_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }
        //buton promovare angajati
        private void buttonPromovareAngajati_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();
        }
        //buton aprobare angajat nou
        private void buttonAprobareAngajatNou_Click(object sender, EventArgs e)
        {
            Form aprobareAngajat = new Aprobare_Angajare();
            this.Hide();
            aprobareAngajat.ShowDialog();
            this.Show();
        }
        //buton adaugare angajat
        private void buttonAdaugareAngajat_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }


        //buton delogare
        private void ButtonDelogare_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);
        }

        
        //buton inapoi
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
