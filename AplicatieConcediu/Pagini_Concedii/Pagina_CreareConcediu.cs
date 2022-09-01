
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        private void Pagin_CreareConcediu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.
            //    this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            List<TipConcediu> lista = new List<TipConcediu>();
            List<Angajat> listaAngajat = new List<Angajat>();
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {

                    //retrieve the SQL Server instance version
                    string query = string.Format(" SELECT * FROM TipConcediu");
                    Globals.EmailUserActual = "1234";
                    string query2 = string.Format("SELECT * FROM Angajat WHERE idEchipa = (SELECT idEchipa FROM Angajat WHERE Email =  '"+ Globals.EmailUserActual +"') and Email <> '" + Globals.EmailUserActual + "'");
                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var tipconcediu = new TipConcediu();
                            var x = dr.GetValue(0);
                            var y = dr.GetValue(1);
                            var z = dr.GetValue(2);
                            tipconcediu.id = (int)x;
                            tipconcediu.Nume = y.ToString();
                            tipconcediu.Cod = z.ToString();
                            lista.Add(tipconcediu);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();

                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    Angajat inlocuitor; 
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            inlocuitor = new Angajat();
                            var x = dr2.GetValue(0);
                            var y = dr2.GetValue(1);
                            var z = dr2.GetValue(2);
                            inlocuitor.id = (int)x;
                            inlocuitor.Nume = y.ToString();
                            inlocuitor.Prenume = z.ToString();
                            listaAngajat.Add(inlocuitor);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close connection
                    
                    dr2.Close();
                    conn.Close();

                    comboBox1.DataSource = lista;
                    comboBox1.DisplayMember = "Nume";
                    comboBox1.ValueMember = "Id";

                    comboBox2.DataSource = listaAngajat;
                    comboBox2.DisplayMember = "NumeComplet";
                    comboBox2.ValueMember = "Id";
                }

            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
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
            //
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
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {



                    if (lastDayOfWeek >= 7)
                        zileConcediu -= 2; // Altfel scadem doar sambata si duminica
                    else if (lastDayOfWeek >= 6)
                        zileConcediu -= 1;
                    else if (lastDayOfWeek <= 5)
                        zileConcediu -= 1; // Trebuie sa scadem sambata


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

        private void button1_Click(object sender, EventArgs e)
        {
            string data_incepere = dateTimePicker1.Text;
            string data_incetare = dateTimePicker2.Text;
            string motiv = textBox2.Text;
            string data_incepre_formatata = data_incepere.Substring(data_incepere.IndexOf(',') + 2, data_incepere.Length - 2 - data_incepere.IndexOf(','));
            string data_incetare_formatata = data_incetare.Substring(data_incetare.IndexOf(',') + 2, data_incetare.Length - 2 - data_incetare.IndexOf(','));

            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    conn.Open();
                    Globals.IdUserActual1 = 1;
                    string sqlText = "insert into Concediu(TipConcediuId, DataInceput, DataSfarsit,InlocuitorId, Comentarii, StareConcediuId, AngajatId)" +
                   "values('" + comboBox1.SelectedValue.ToString() + "','" + data_incepre_formatata + "','" + data_incetare_formatata + "','" + comboBox2.SelectedValue.ToString() + "','" + motiv + "','" + 3 + "','" + Globals.IdUserActual1.ToString() + "')";
                    SqlCommand cmdInsert = new SqlCommand(sqlText, conn);
                    cmdInsert.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id";      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id"; 
        }
    }
}
