
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AplicatieConcediu
{
    public partial class Pagina_CreareConcediu : Form
    {
       
        public Pagina_CreareConcediu()
        {
            InitializeComponent();
        }

        List<Angajat> inlocuitori = new List<Angajat>();
        public List<XD.Models.TipConcediu> GetTipuriConcediu()
        {
            var url = "http://localhost:5107/CreareConcediu/TipuriConcediu";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.TipConcediu> list = new List<XD.Models.TipConcediu>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            TipConcediu t;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.TipConcediu>>(result, settings);
            }
            return list;
        }
        List<int> ListaId = new List<int>();
        public List<XD.Models.Angajat> GetInlocuitori()
        {
            Globals.IdUserActual1 = 2;
            var url = "http://localhost:5107/CreareConcediu/GetInlocuitor/" + Globals.IdUserActual1 ;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            List<XD.Models.Angajat> list = new List<XD.Models.Angajat>();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                list = JsonConvert.DeserializeObject<List<XD.Models.Angajat>>(result, settings);
            }
            return list;
        }
        private void Pagin_CreareConcediu_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.
            //    this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            List<TipConcediu> lista = new List<TipConcediu>();
            List<Angajat> listaAngajat = new List<Angajat>();


            //try
            //{
            //    //sql connection object
            //    using (SqlConnection conn = new SqlConnection(Globals.ConnString))
            //    {

            //        //retrieve the SQL Server instance version
            //        string query = string.Format(" SELECT * FROM TipConcediu");          
            //        Globals.EmailUserActual = "popescuioan@yahoo.com";
            //        string query2 = string.Format("SELECT * FROM Angajat WHERE idEchipa = (SELECT idEchipa FROM Angajat WHERE Email =  '"+ Globals.EmailUserActual +"') and Email <> '" + Globals.EmailUserActual + "'");
            //        //define the SqlCommand object
            //        SqlCommand cmd = new SqlCommand(query, conn);
            //        SqlCommand cmd2 = new SqlCommand(query2, conn);
            //        //open connection
            //        conn.Open();

            //        //execute the SQLCommand
            //        SqlDataReader dr = cmd.ExecuteReader();
                    

            //        //check if there are records
            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                var tipconcediu = new TipConcediu();
            //                var x = dr.GetValue(0);
            //                var y = dr.GetValue(1);
            //                var z = dr.GetValue(2);
            //                tipconcediu.id = (int)x;
            //                tipconcediu.Nume = y.ToString();
            //                tipconcediu.Cod = z.ToString();
            //                lista.Add(tipconcediu);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No data found.");
            //        }

            //        //close data reader
            //        dr.Close();

            //        SqlDataReader dr2 = cmd2.ExecuteReader();
            //        Angajat inlocuitor; 
            //        if (dr2.HasRows)
            //        {
            //            while (dr2.Read())
            //            {
            //                inlocuitor = new Angajat();
            //                var x = dr2.GetValue(0);
            //                var y = dr2.GetValue(1);
            //                var z = dr2.GetValue(2);
            //                var n = dr2.GetValue(12);
            //                inlocuitor.id = (int)x;
            //                inlocuitor.Nume = y.ToString();
            //                inlocuitor.Prenume = z.ToString();
            //                listaAngajat.Add(inlocuitor);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No data found.");
            //        }

            //        //close connection
                    
            //        dr2.Close();
            //        conn.Close();

                    comboBox1.DataSource = GetTipuriConcediu();
                    comboBox1.DisplayMember = "Nume";
                    comboBox1.ValueMember = "Id";

            List<XD.Models.Angajat> list2 = GetInlocuitori();
            foreach(var angajat in list2)
            {
                Angajat inlocuitor = new Angajat();
                inlocuitor.Nume = angajat.Nume;
                inlocuitor.Prenume = angajat.Prenume;
                inlocuitori.Add(inlocuitor);
                ListaId.Add(angajat.Id);

            }
                    comboBox2.DataSource = inlocuitori;
                    comboBox2.DisplayMember = "NumeComplet";
                    comboBox2.ValueMember = "id";
                

            
            //catch (Exception ex)
            //{
            //    //display error message
            //    Console.WriteLine("Exception: " + ex.Message);
            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            DateTime dataIncepere = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime dataIncetare = Convert.ToDateTime(dateTimePicker2.Value);

            if (dataIncepere > dataIncetare)
            {
                textBox1.Text = "0";
                MessageBox.Show("Data de incetare a concediului este mai recenta decat data de incepere!");
                button1.Enabled = false;
            }
            else
            {
                textBox1.Text = ZileConcediu(dataIncepere, dataIncetare).ToString();
            }


        }

        public static int ZileConcediu(DateTime firstDay, DateTime lastDay)
        {
            int year = 2022;
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(year, 1, 1));   // Anul nou
            holidays.Add(new DateTime(year, 1, 2));   // Anul nou
            holidays.Add(new DateTime(year, 1, 24));  // Unirea principatelor
            holidays.Add(new DateTime(year, 5, 1));   // Ziua muncii
            holidays.Add(new DateTime(year, 6, 1));   // Ziua copilului
            holidays.Add(new DateTime(year, 8, 15));  // Adormirea Maicii Domnului
            holidays.Add(new DateTime(year, 11, 30)); // Sfantul Andrei
            holidays.Add(new DateTime(year, 12, 1));  // Ziua Nationala a Romaniei
            holidays.Add(new DateTime(year, 12, 25)); // Prima zi de Craciun
            holidays.Add(new DateTime(year, 12, 26)); // A doua zi de Craciun




            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            TimeSpan span = lastDay - firstDay;
            int zileConcediu = span.Days + 1;
            int fullWeekCount = zileConcediu / 7;
            if (zileConcediu > fullWeekCount * 7)
            {
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                firstDayOfWeek = firstDayOfWeek == 0 ? 7 : firstDayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {



                    if (lastDayOfWeek >= 7)
                        zileConcediu -= 2; // Altfel scadem doar sambata si duminica
                    else if (lastDayOfWeek >= 6)
                        zileConcediu -= 1;

                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Scadem doar duminica
                    zileConcediu -= 1;
            }
            zileConcediu -= fullWeekCount + fullWeekCount;

            foreach (DateTime bankHoliday in holidays)
            {
                DateTime bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    zileConcediu--;
            }
            return zileConcediu;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            DateTime dataIncepere = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime dataIncetare = Convert.ToDateTime(dateTimePicker2.Value);

            if (dataIncepere > dataIncetare)
            {
                textBox1.Text = "0";
                MessageBox.Show("zile de concediu negative");
            }
            else
            {
                textBox1.Text = ZileConcediu(dataIncepere, dataIncetare).ToString();
            }
        }

       
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string data_incepere = dateTimePicker1.Text;
            string data_incetare = dateTimePicker2.Text;
            string motiv = textBox2.Text;
            string data_incepre_formatata = data_incepere.Substring(data_incepere.IndexOf(',') + 2, data_incepere.Length - 2 - data_incepere.IndexOf(','));
            string data_incetare_formatata = data_incetare.Substring(data_incetare.IndexOf(',') + 2, data_incetare.Length - 2 - data_incetare.IndexOf(','));

            HttpClient httpClient = new HttpClient();

            XD.Models.Concediu c = new XD.Models.Concediu();
            c.TipConcediuId = comboBox1.SelectedIndex+1;
            c.DataInceput = dateTimePicker1.Value;
            c.DataSfarsit = dateTimePicker2.Value;
            c.InlocuitorId = ListaId[comboBox2.SelectedIndex];
            c.Comentarii = motiv;
            c.StareConcediuId = 3;
            c.AngajatId = Globals.IdUserActual1;
            c.Angajat = null;
            c.Inlocuitor = null;
            c.TipConcediu = null;
            c.StareConcediu = null;


            string jsonString = JsonConvert.SerializeObject(c);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5107/CreareConcediu/PostConcediu", stringContent);
            response.EnsureSuccessStatusCode();



            //HttpContent content = response.Content;
            //Task<string> result = content.ReadAsStringAsync();
            //string res = result.Result;
            //int NrZileConcediu =  
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(Globals.ConnString))
            //    {
            //        conn.Open();
            //       // Globals.IdUserActual1 = 1;
            //        string sqlText = "insert into Concediu(TipConcediuId, DataInceput, DataSfarsit,InlocuitorId, Comentarii, StareConcediuId, AngajatId)" +
            //       "values('" + comboBox1.SelectedValue.ToString() + "','" + data_incepre_formatata + "','" + data_incetare_formatata + "','" + comboBox2.SelectedValue.ToString() + "','" + motiv + "','" + 3 + "','" + Globals.IdUserActual1.ToString() + "')";
            //        SqlCommand cmdInsert = new SqlCommand(sqlText, conn);
            //        cmdInsert.ExecuteNonQuery();
            //         string sqlText2 = "update Angajat set NumarZileConceiduRamase = NumarZileConceiduRamase - '" + Int32.Parse(textBox1.Text) + "' where Id = '"+Globals.IdUserActual1.ToString()+"' ";
            //        SqlCommand cmdUpdate = new SqlCommand(sqlText2, conn);
            //        cmdUpdate.ExecuteNonQuery();

            //        conn.Close();
            //    }
            //}
            //catch (Exception ex)
            //{ 
            //    Console.WriteLine("Exception: " + ex.Message);
            //}

            // MessageBox.Show("Data de incetare a concediului!");
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id"; 
        }
    }
}
