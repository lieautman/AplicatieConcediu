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
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Collections;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class FormareEchipaAngajatPromovat : Form
    {
        private List<AngajatiListaPentruFormareEchipaNoua> listaAngajati = new List<AngajatiListaPentruFormareEchipaNoua>();
        private List<Echipa> numeEchipa = new List<Echipa>();
        public FormareEchipaAngajatPromovat()
        {
            InitializeComponent();
        }

        private void FormareEchipaAngajatPromovat_Load(object sender, EventArgs e)
        {

            //inserare in lable nume si prenume angajat din bd
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Nume, Prenume from Angajat where Email = '" + Globals.EmailManager + "'", out conn1);
            string numesiprenume = "";
            while (reader1.Read())
            {
                numesiprenume += reader1["Nume"];
                numesiprenume += " ";
                numesiprenume += reader1["Prenume"];
            }
            reader1.Close();
            conn1.Close();
            label3.Text = numesiprenume;

            //inserare in gridview date despre angajati(care nu sunt si manageri)
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("Select Nume, Prenume, Email,DataAngajarii, DataNasterii, CNP, idEchipa from Angajat where ManagerId is not null ", out conn);
            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                DateTime dataAngajarii;
                if (reader[4] != DBNull.Value)
                    dataAngajarii = (DateTime)reader[4];
                else dataAngajarii = (DateTime)reader[""];


                DateTime dataNasterii = (DateTime)reader["DataNasterii"];
                string cNP = (string)reader["CNP"];
                int idEchipaa;
                if (reader[6] != DBNull.Value)
                {
                    idEchipaa = Convert.ToInt32(reader.GetValue(6));
                }
                else idEchipaa = -1;

                AngajatiListaPentruFormareEchipaNoua angajat = new AngajatiListaPentruFormareEchipaNoua(nume, prenume, email, dataAngajarii, dataNasterii, cNP, idEchipaa);
                listaAngajati.Add(angajat);
            }

            dataGridView1.DataSource = listaAngajati;

            conn.Close();

            //atribuire poza pe form load in functie de id logat
            byte[] poza = { };
            bool isOk = true;
            string query2 = "SELECT Poza FROM Angajat WHERE Email ='" + Globals.EmailManager + "'";
            SqlConnection connection2 = new SqlConnection();
            SqlDataReader reader2 = Globals.executeQuery(query2, out connection2);

            while (reader2.Read())
            {
                if (reader2["Poza"] != DBNull.Value)
                    poza = (byte[])reader2["Poza"];
                else
                    isOk = false;

            }
            reader2.Close();
            connection2.Close();
            if (isOk == true)
                pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));


            //combobox
            using (SqlConnection connEchipa = new SqlConnection(Globals.ConnString))
            {
                string query = string.Format("select Nume from Echipa");

                //definire comenzi
                SqlCommand cmd = new SqlCommand(query, connEchipa);
                connEchipa.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                Console.WriteLine("Retrieved records:");

                //verificare existenta inregistrari
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var echipa = new Echipa();
                        var y = dr.GetValue(0);
                        echipa.Nume = y.ToString();
                        numeEchipa.Add(echipa);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
                dr.Close();

                connEchipa.Close();

                comboBox1.DataSource = numeEchipa;
                comboBox1.DisplayMember = "Nume";
                comboBox1.ValueMember = "Id";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          


            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //insert in echipa
            int id = comboBox1.SelectedIndex + 1;
            string updatare = "UPDATE Angajat set idEchipa= '" + id + "'Where Email='" + Globals.EmailManager + "'";
            SqlConnection connection3 = new SqlConnection();
            SqlDataReader reader3 = Globals.executeQuery(updatare, out connection3);
            connection3.Close();

            
            //refresh fortat
            FormareEchipaAngajatPromovat f = new FormareEchipaAngajatPromovat();
            this.Hide();
            this.Close();
            f.ShowDialog();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
