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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using AplicatieConcediu.Pagini_Actiuni;

namespace AplicatieConcediu
{
    public partial class Pagina_Profil_Angajat : Form
    {
        public Pagina_Profil_Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form concedii = new Pagina_ConcediileMele();
            this.Hide();
            concedii.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globals.EmailUserViewed = "";
            this.Close();
        }

        private void Pagina_Profil_Angajat_Load(object sender, EventArgs e)
        {
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
                button7.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }

            string query = "SELECT * FROM Angajat WHERE Email ='"+ emailFolositLaSelect+"'";
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery(query,out connection);


            while(reader.Read())
            {
                string nume = (string)reader["Nume"];
                label12.Text = nume;
                string prenume = (string)reader["Prenume"];
                label13.Text = prenume;


                if (reader["EsteAdmin"] is true)
                {
                    label14.Text = "Administrator";
                    button4.Show();
                    button5.Show();
                    button6.Show();

                }
                else if (reader["ManagerId"] == DBNull.Value)
                {
                    label14.Text = "Manager";
                    button4.Show();
                    button5.Show();
                }
                else
                {
                    label14.Text = "Angajat";
                    button4.Hide();
                    button5.Hide();
                    button6.Hide();
                }



                if (reader["DataAngajarii"]!=
                    System.DBNull.Value)
                {
                    string data_angajare = (string)reader["DataAngajarii"];
                    label15.Text = data_angajare;
                }
                string email = (string)reader["Email"];
                label16.Text = email;
                string telefon = (string)reader["Numartelefon"];
                label17.Text = telefon;
                DateTime data_nastere = (DateTime)reader["DataNasterii"];
                label18.Text = data_nastere.ToString().Substring(0,10);
                string cnp = (string)reader["CNP"];
                label19.Text = cnp;
                string serie_numar = (string)reader["SeriaNumarBuletin"];
                label20.Text = serie_numar.Substring(0, 2);
                label21.Text = serie_numar.Substring(2);
                string salariu = reader["Salariu"].ToString();
                label22.Text = salariu;

            }
            reader.Close();
            connection.Close();


            //creare conexiune pentru a cere o poza

            byte[] poza = { };
            bool isOk = true;
            string query1 = "SELECT Poza FROM Angajat WHERE Email ='" + emailFolositLaSelect + "'";
            SqlConnection connection1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery(query1, out connection1);

            while (reader1.Read()) 
            {
                if (reader1["Poza"] != DBNull.Value)
                    poza = (byte[])reader1["Poza"];
                else
                    isOk = false;
            
            }
            reader1.Close();
            connection1.Close();
            if(isOk==true)
                pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form creareconcediu = new Pagina_CreareConcediu();
            this.Hide();
            creareconcediu.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
              //  emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else {
                // emailFolositLaSelect = Globals.EmailUserActual;
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog1.FileName;
                        byte[] bytes = File.ReadAllBytes(fileName);
                        string contentType = "";
                        //Set the contenttype based on File Extension

                        switch (Path.GetExtension(fileName))
                        {
                            case ".jpg":
                                contentType = "image/jpeg";
                                break;
                            case ".png":
                                contentType = "image/png";
                                break;
                            case ".gif":
                                contentType = "image/gif";
                                break;
                            case ".bmp":
                                contentType = "image/bmp";
                                break;
                        }


                        SqlConnection conn = new SqlConnection(Globals.ConnString);
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = conn;
                        cmd.CommandText = "update Angajat set Poza= @imgdata where Email = @email";

                        SqlParameter photo = new SqlParameter("@imgdata", bytes);
                        cmd.Parameters.Add(photo);

                        SqlParameter email = new SqlParameter("@email", Globals.EmailUserActual);
                        cmd.Parameters.Add(email);


                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        pictureBox2.Image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form adaugare_angajat = new Adaugare_Angajat();
            this.Hide();
            adaugare_angajat.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();

        }
    }
}
