﻿
using System;
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

                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            var inlocuitor = new Angajat();
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

                    comboBox2.DataSource = listaAngajat;
                    //comboBox2.
                    comboBox2.DisplayMember = "NumeComplet";
                }

            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }

            //SqlConnection con = new SqlConnection("server=.; Initial Catalog=Northwind;Integrated Security=SSPI");

            //SqlCommand cmd = new SqlCommand();


            //con.Open();

            //cmd.Connection = con;

            //cmd.CommandText = "SELECT * FROM TipConcediu";

            ////SqlDataReader dr = cmd.ExecuteReader();



            //    while (dr.Read())

            //    {

            //        comboBox1.Items.Add(dr["CompanyName"]);

            //    }

            //    con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            textBox1.Text = dateTimePicker2.Value.Date.AddDays(-dateTimePicker1.Value.Date.Day).Day.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            textBox1.Text = dateTimePicker2.Value.Date.AddDays(-dateTimePicker1.Value.Date.Day).Day.ToString();

        }

       
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}