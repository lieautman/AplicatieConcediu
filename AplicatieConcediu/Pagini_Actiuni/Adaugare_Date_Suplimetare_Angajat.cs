using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Adaugare_Date_Suplimetare_Angajat : Form
    {
        public Adaugare_Date_Suplimetare_Angajat()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        List<Angajat> listaManager = new List<Angajat>();
        
        private void Angajare_Load(object sender, EventArgs e)
        {

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" SELECT * FROM Angajat WHERE ManagerId is null AND Email<>'" + Globals.EmailUserViewed + "'");
                    SqlCommand cmd = new SqlCommand(query, conn);
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
                            var listamanageri = new Angajat();
                            var x = dr.GetValue(1);
                            var y = dr.GetValue(2);
                            var z = dr.GetValue(0);

                            listamanageri.id = (int)z;
                            listamanageri.Nume = x.ToString();
                            listamanageri.Prenume = y.ToString();

                            listaManager.Add(listamanageri);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();
                    conn.Close();


                    comboBox1.DataSource = listaManager;
                    comboBox1.DisplayMember = "NumeComplet";
                    comboBox1.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string DataAngajarii = dateTimePicker1.Text;
            string NumarZileConcediu = textBox1.Text;
            string Salariu = textBox2.Text;
            string Manager = comboBox1.Text;
            bool isError = false;
            try
            {
                Int32.Parse(NumarZileConcediu);
                errorProvider1.SetError(textBox1, "");
            }
            catch
            {

                errorProvider1.SetError(textBox1, "Introduceti un numar de zile valid");
                isError = true;

            }
            try
            {
                Int32.Parse(Salariu);
                errorProvider1.SetError(textBox2, "");

            }
            catch
            {

                errorProvider1.SetError(textBox2, "Introduceti un salariu  numeric");
                isError = true;

            }

            string data_angajarii_formatata = DataAngajarii.Substring(DataAngajarii.IndexOf(',') + 2, DataAngajarii.Length - 2 - DataAngajarii.IndexOf(','));

            try
            { //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" UPDATE Angajat  SET DataAngajarii ='" +data_angajarii_formatata  + "',ManagerId ='" + comboBox1.SelectedValue.ToString() + "' ,NumarZileConceiduRamase = '" + NumarZileConcediu  + "',Salariu = '" + Salariu + "', EsteAngajatCuActeInRegula = '" +  1 + "' WHERE Email = '" + Globals.EmailAngajatCuActeNeinregula + "'  ");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    Globals.executeNonQuery(query);

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                   

               
                    conn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
        }
    }
}
