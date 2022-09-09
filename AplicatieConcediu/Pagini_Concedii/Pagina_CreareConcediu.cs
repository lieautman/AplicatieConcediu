
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
		private readonly object inlocuitor;

		public List<XD.Models.Angajat> GetInlocuitori()
        {
            //Globals.IdUserActual1 = 2;
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

		public Dictionary<int, int > GetNrZileConcediu()
		{
			var url = "http://localhost:5107/CreareConcediu/GetNrZileConcediu/" + Globals.IdUserActual1;
			var httpRequest = (HttpWebRequest)WebRequest.Create(url);
			//List<DictionarZileConcediu> list = new List<DictionarZileConcediu>();
			Dictionary<int, int> dictPreluatDinBackend = new Dictionary<int, int>();
			var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				var result = streamReader.ReadToEnd();
				dictPreluatDinBackend = JsonConvert.DeserializeObject<Dictionary<int,int>>(result);
			}
			return dictPreluatDinBackend;
		}

		Dictionary<int, int> DictionarZile = new Dictionary<int, int>();

		private void Pagin_CreareConcediu_Load(object sender, EventArgs e)
        {
			DictionarZile = GetNrZileConcediu();
			btnAdaugare.Enabled = false;
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.
            //    this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            List<TipConcediu> lista = new List<TipConcediu>();
            List<Angajat> listaAngajat = new List<Angajat>();


			cbTipConcediu.DisplayMember = "Nume";
			cbTipConcediu.ValueMember = "Id";
			cbTipConcediu.DataSource = new BindingSource(GetTipuriConcediu(), null);
                    

            List<XD.Models.Angajat> list2 = GetInlocuitori();
            foreach(var angajat in list2)
            {
                Angajat inlocuitor = new Angajat();
                inlocuitor.Nume = angajat.Nume;
                inlocuitor.Prenume = angajat.Prenume;
                inlocuitori.Add(inlocuitor);
                ListaId.Add(angajat.Id);
				

			}
			//string emailFolositLaSelect;
			//if (Globals.EmailUserViewed != "")
			//{
			//	emailFolositLaSelect = Globals.EmailUserViewed;
			//}
			//else
		//	{
			//	emailFolositLaSelect = Globals.EmailUserActual;
			//}
			//Angajat a = new Angajat();
			 //a = GetNrZileConcediu(emailFolositLaSelect);

			//lbRezultatZileConcediuDisponibile.Text = a.NumarZileConceiduRamase.ToString();

			cbInlocuitori.DataSource = new BindingSource(inlocuitori, null);
                    cbInlocuitori.DisplayMember = "NumeComplet";
                    cbInlocuitori.ValueMember = "id";




            //catch (Exception ex)
            //{
            //    //display error message
            //    Console.WriteLine("Exception: " + ex.Message);
            //}

            cbTipConcediu.Text = "";
            cbInlocuitori.Text = "";

            labelEroareInlocuitor.Text = "";
            labelEroareTipConcediu.Text = "";

        }

		



		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btnAdaugare.Enabled = true;
            DateTime dataIncepere = Convert.ToDateTime(dateTimePickerDataIncepere.Value);
            DateTime dataIncetare = Convert.ToDateTime(dateTimePickerDataIncetare.Value);

            if (dataIncepere > dataIncetare)
            {
                tbTotalZileConcediuCreat.Text = "0";
                MessageBox.Show("Data de incetare a concediului este mai recenta decat data de incepere!");
                btnAdaugare.Enabled = false;
            }
            else
            {
                tbTotalZileConcediuCreat.Text = ZileConcediu(dataIncepere, dataIncetare).ToString();
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
            btnAdaugare.Enabled = true;
            DateTime dataIncepere = Convert.ToDateTime(dateTimePickerDataIncepere.Value);
            DateTime dataIncetare = Convert.ToDateTime(dateTimePickerDataIncetare.Value);

            if (dataIncepere > dataIncetare)
            {
                tbTotalZileConcediuCreat.Text = "0";
                MessageBox.Show("zile de concediu negative");
            }
            else
            {
                tbTotalZileConcediuCreat.Text = ZileConcediu(dataIncepere, dataIncetare).ToString();
            }
		
		}

       
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            if (cbTipConcediu.Text == "")
            {
                isOk = false;
                labelEroareTipConcediu.Text = "* Tip concediu neselectat";
            }
            if(cbInlocuitori.Text == "")
            {
                isOk = false;
                labelEroareInlocuitor.Text = "*Inlocuitor neselectat";
            }


			if (Convert.ToInt32(tbTotalZileConcediuCreat.Text) > Convert.ToInt32(lbRezultatZileConcediuDisponibile.Text))
			{
				btnAdaugare.Enabled = false;
				MessageBox.Show("Numarul de zile de concediu selectat depaseste numarul de zile de concediu disponibile!");
				return;

			}
			string data_incepere = dateTimePickerDataIncepere.Text;
            string data_incetare = dateTimePickerDataIncetare.Text;
            string motiv = tbMotiv.Text;
            string data_incepre_formatata = data_incepere.Substring(data_incepere.IndexOf(',') + 2, data_incepere.Length - 2 - data_incepere.IndexOf(','));
            string data_incetare_formatata = data_incetare.Substring(data_incetare.IndexOf(',') + 2, data_incetare.Length - 2 - data_incetare.IndexOf(','));

            HttpClient httpClient = new HttpClient();

            XD.Models.Concediu c = new XD.Models.Concediu();
            c.TipConcediuId = (int)cbTipConcediu.SelectedValue;
            c.DataInceput = dateTimePickerDataIncepere.Value;
            c.DataSfarsit = dateTimePickerDataIncetare.Value;
            c.InlocuitorId = ListaId[cbInlocuitori.SelectedIndex];
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

            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (cbTipConcediu.SelectedValue == null)
				return;
			lbRezultatZileConcediuDisponibile.Text = DictionarZile[(int)cbTipConcediu.SelectedValue].ToString();

		}
    }
}
