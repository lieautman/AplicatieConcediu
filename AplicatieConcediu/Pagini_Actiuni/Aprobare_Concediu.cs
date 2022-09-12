using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AplicatieConcediu.DB_Classess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.Json.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Text.Json;
using System.Net.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static System.Net.WebRequestMethods;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Aprobare_Concediu : Form
    {
        private List<AfisareConcedii> listaConcedii = new List<AfisareConcedii>();
       
        public Aprobare_Concediu()
        {
            InitializeComponent();
        }

       
        public List<XD.Models.Concediu> GetConcedii()
        {
            var url = "http://localhost:5107/Concediu/GetConcediiSpreAprobare";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Concediu> list = new List<XD.Models.Concediu>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.Concediu>>(result,settings );
            }
            return list;
        }

        public XD.Models.Concediu GetConcediuById(int id)
        {
            
            var url =  String.Format("http://localhost:5107/Concediu/GetConcediuById/{0}", id);
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            XD.Models.Concediu concediu = new XD.Models.Concediu();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                concediu = JsonConvert.DeserializeObject<XD.Models.Concediu>(result, settings);
            }
            return concediu;
        }

        private void Aprobare_Concediu_Load(object sender, EventArgs e)
        {

            if (Globals.IdManager == null && Globals.IsAdmin == false)
                buttonPromovareAngajati.Hide();
            List<XD.Models.Concediu> lista2 = GetConcedii();
            

            foreach(var concediu in lista2)
            {
                AfisareConcedii afisareConcedii = new AfisareConcedii();
                afisareConcedii.IdConcediu = concediu.Id.ToString();
                afisareConcedii.NumeTipConcediu = concediu.TipConcediu.Nume;
                afisareConcedii.DataInceput = concediu.DataInceput;
                afisareConcedii.DataSfarsit = concediu.DataSfarsit;
                afisareConcedii.NumeInlocuitor = concediu.Inlocuitor.Nume;
                afisareConcedii.Comentarii = concediu.Comentarii;
                afisareConcedii.NumeAngajat = concediu.Angajat.Nume;
                listaConcedii.Add(afisareConcedii);
            }

            dataGridView1.DataSource = listaConcedii;
            
            dataGridView1.Columns["IdConcediu"].Visible = false;
            dataGridView1.Columns["NumeTipConcediu"].HeaderText = "Tipul Concediului";
            dataGridView1.Columns["DataInceput"].HeaderText = "Data de inceput";
            dataGridView1.Columns["DataSfarsit"].HeaderText = "Data de sfarsit";
            dataGridView1.Columns["NumeInlocuitor"].HeaderText = "Inlocuitorul";
            dataGridView1.Columns["Comentarii"].HeaderText = "Motivul";
            dataGridView1.Columns["NumeAngajat"].HeaderText = "Angajatul";
            dataGridView1.Columns["StareConcediu"].Visible = false;






            DataGridViewButtonColumn butonAprobare = new DataGridViewButtonColumn();
                    butonAprobare.HeaderText = "Aprobare";
                    butonAprobare.Text = "Aprobare ";
                    butonAprobare.Tag = (Action<AfisareConcedii>)ClickHandlerAprobare;
                    butonAprobare.UseColumnTextForButtonValue = true;

             DataGridViewButtonColumn butonRespinge = new DataGridViewButtonColumn();
                    butonRespinge.HeaderText = "Respinge";
                    butonRespinge.Text = "Respingere ";
                    butonRespinge.Tag = (Action<AfisareConcedii>)ClickHandlerRespingere;
                    butonRespinge.UseColumnTextForButtonValue = true;


                    this.dataGridView1.Columns.Add(butonAprobare);
                    this.dataGridView1.Columns.Add(butonRespinge);
                   
                    dataGridView1.CellContentClick += Buton_CellContentClick;


            for(int i = 0; i< listaConcedii.Count; i++)
            {
                butonAprobare.FlatStyle = FlatStyle.Flat;
                var but1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[8]);
                but1.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[8].Style.BackColor = Color.FromArgb(92, 183, 164);
                dataGridView1.Rows[i].Cells[8].Style.ForeColor = Color.FromArgb(9, 32, 30);

                butonRespinge.FlatStyle = FlatStyle.Flat;
                var but2 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[9]);
                but2.FlatStyle = FlatStyle.Flat;
                dataGridView1.Rows[i].Cells[9].Style.BackColor = Color.FromArgb(249,80,0);
                dataGridView1.Rows[i].Cells[9].Style.ForeColor = Color.FromArgb(9, 32, 30);
            }




       

            //}
            dataGridView1.ReadOnly = true;
            dataGridView1.EnableHeadersVisualStyles = false; 
            dataGridView1.AutoResizeColumns();

            //}
            /*catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }*/
        }

        private async Task modifStareConcedii(AfisareConcedii a)
        {
            

        }

        private async void  ClickHandlerAprobare(AfisareConcedii a)
        {

            HttpClient httpClient = new HttpClient();


            XD.Models.Concediu c = GetConcediuById(Int32.Parse(a.IdConcediu));
            c.StareConcediuId = 1;
            c.Angajat = null;
            c.Inlocuitor = null;
            c.TipConcediu = null;
            c.StareConcediu = null;
           

            string jsonString = JsonConvert.SerializeObject(c);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/Concediu/UpdateStareConcediu", stringContent);
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;


            Aprobare_Concediu form = new Aprobare_Concediu();
            this.Hide();
            this.Close();
            form.ShowDialog();
            


        }

        private async void ClickHandlerRespingere(AfisareConcedii a)
        {
            HttpClient httpClient = new HttpClient();


            XD.Models.Concediu c = GetConcediuById(Int32.Parse(a.IdConcediu));
            c.StareConcediuId = 2;
            c.Angajat = null;
            c.Inlocuitor = null;
            c.TipConcediu = null;
            c.StareConcediu = null;

            string jsonString = JsonSerializer.Serialize<XD.Models.Concediu>(c);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/Concediu/UpdateStareConcediu", stringContent);
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            string res = result.Result;

            Aprobare_Concediu form = new Aprobare_Concediu();
            this.Hide();
            this.Close();
            form.ShowDialog();


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
                var clickHandler = (Action<AfisareConcedii>)grid.Columns[e.ColumnIndex].Tag;
                var concediu = (AfisareConcedii)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(concediu);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();
            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form aprobareAngajat = new Aprobare_Angajare();
            this.Hide();
            aprobareAngajat.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);
        }
        int count = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;

            if (count % 2 != 0)
            {

                button3.Show();
                button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();
                buttonPromovareAngajati.Show();
                button9.Show();
                button10.Show();
                button11.Show();


                if (Globals.IdManager == null && Globals.IsAdmin == false)
                    buttonPromovareAngajati.Hide();

            }
            else
            {

                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                buttonPromovareAngajati.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
    }
}
