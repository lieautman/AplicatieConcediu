
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



namespace AplicatieConcediu.Pagini_Concedii
{
    public partial class Pagin_CreareConcediu : Form
    {
        public Pagin_CreareConcediu()
        {
            InitializeComponent();
        }

        private void Pagin_CreareConcediu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.
            //    this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            List<TipConcediu> lista = new List<TipConcediu>();
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {

                    //retrieve the SQL Server instance version
                    string query = string.Format(" SELECT * FROM TipConcediu");
                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);

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

                    //close connection
                    conn.Close();

                    comboBox1.DataSource = lista;
                    comboBox1.DisplayMember = "Nume";
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

       
    }
}       
