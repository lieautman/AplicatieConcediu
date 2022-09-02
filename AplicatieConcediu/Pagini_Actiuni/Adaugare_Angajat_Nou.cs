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
using AplicatieConcediu.DB_Classess;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Adaugare_Angajat_Nou : Form
    {
        private List<Echipa> listaEchipe = new List<Echipa>();
        private List<Angajat> listaManageri = new List<Angajat>();
        public Adaugare_Angajat_Nou()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Adaugare_Angajat_Nou_Load(object sender, EventArgs e)
        {
            
            try
            { //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {

                    //retrieve the SQL Server instance version
                    string query = string.Format(" SELECT * FROM Echipa");
                    string query1 = string.Format("SELECT * FROM Angajat WHERE ManagerId is null AND EsteAngajatCuActeInRegula = 1") ;
                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlCommand cmd2 = new SqlCommand(query1, conn);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

       
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var echipeid = new Echipa();
                            var x = dr.GetValue(0);
                            var y = dr.GetValue(1);
                            echipeid.Id = (int)x;
                            echipeid.Nume = y.ToString();
                            listaEchipe.Add(echipeid);
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
                            var managerId = new Angajat();
                            var x = dr2.GetValue(0);
                            var y = dr2.GetValue(1);
                            var z = dr2.GetValue(2);
                            managerId.id = (int)x;
                            managerId.Nume = y.ToString();
                            managerId.Prenume = z.ToString();
                            listaManageri.Add(managerId);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close connection

                    dr2.Close();
                    conn.Close();

                    //check if there are records
                    comboBox1.DataSource = listaEchipe;
                    comboBox1.DisplayMember = "Nume";
                    comboBox1.ValueMember = "id";

                    comboBox2.DataSource = listaManageri;
                    //comboBox2.
                    comboBox2.DisplayMember = "NumeComplet";
                    comboBox2.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string data_nastere = dateTimePicker1.Text;
            string email = textBox4.Text;
            string nr_telefon = textBox8.Text;
            string cnp = textBox5.Text;
            string SerieNrBuletin = textBox6.Text;
            string parola = textBox10.Text;
            string data_angajarii = dateTimePicker2.Text;
            string managerid = comboBox2.Text;
            string salariu = textBox3.Text;
            string zileconcediuramase = textBox7.Text;
            string idechipa = comboBox1.Text;
            //
            bool numeNull = false;
            bool prenumeNull = false;
            bool datanastereNull = false;
            bool emailNull = false;
            bool numartelefonNull = false;
            bool cnpNull = false;
            bool serianumarciNul = false;
            bool parolaNull = false;
            bool dataangajariiNull = false;
            bool managerNull = false;
            bool salariuNull = false;
            bool zileconcediuramaseNull = false;
            bool echipaNull = false;

            //verificare daca a lasat campurile goale
            //nume
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Introduceti nume");

            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                numeNull = true;
            }
            //prenume
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Introduceti prenume");

            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                prenumeNull = true;
            }
            //datanastere
            if (dateTimePicker1.Text == "")
            {
                errorProvider1.SetError(dateTimePicker1, "Introduceti data nastere");

            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, "");
                datanastereNull = true;
            }
            //email
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Introduceti email");

            }
            else
            {
                errorProvider1.SetError(textBox4, "");
                emailNull = true;
            }
            //numarul de telefon
            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Introduceti numarul de telefon");

            }
            else
            {
                errorProvider1.SetError(textBox8, "");
                numartelefonNull = true;
            }
            //cnp
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Introduceti cnp");

            }
            else
            {
                errorProvider1.SetError(textBox5, "");
                cnpNull = true;
            }
            //serianrci
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Introduceti seria si numarul CI");

            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
            // parola
            if (textBox10.Text == "")
            {
                errorProvider1.SetError(textBox10, "Introduceti parola");

            }
            else
            {
                errorProvider1.SetError(textBox10, "");
                parolaNull = true;
            }
            // data angajarii
            if (dateTimePicker2.Text == "")
            {
                errorProvider1.SetError(dateTimePicker2, "Introduceti data angajarii");

            }
            else
            {
                errorProvider1.SetError(dateTimePicker2, "");
                dataangajariiNull = true;
            }
            //manager
            if (comboBox2.Text == "")
            {
                errorProvider1.SetError(comboBox2, "Introduceti managerul");

            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
                managerNull = true;
            }
            // salariu
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Introduceti salariul");

            }
            else
            {
                errorProvider1.SetError(textBox3, "");
                salariuNull = true;
            }
            //zile concediu ramase
            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Introduceti zile concediu ramase");

            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                zileconcediuramaseNull = true;
            }
            //echipa
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Introduceti echipa");

            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
                echipaNull = true;
            }
            //formatare data
            string data_nastere_formatata = data_nastere.Substring(data_nastere.IndexOf(',') + 2, data_nastere.Length - 2 - data_nastere.IndexOf(','));
            string data_angajarii_formatata = data_angajarii.Substring(data_angajarii.IndexOf(',') + 2, data_angajarii.Length - 2 - data_angajarii.IndexOf(','));
            int IdManager = comboBox2.SelectedIndex + 1;
            int IdEchipa = comboBox1.SelectedIndex + 1;

            string sqlText = "insert into Angajat(Nume, Prenume, Email,Parola, DataAngajarii, DataNasterii, CNP, SeriaNumarBuletin,Numartelefon,Poza,EsteAdmin,NumarZileConceiduRamase,ManagerId,Salariu, EsteAngajatCuActeInRegula,IdEchipa)" +
            "values('" + nume + "','" + prenume + "','" + email + "','" + parola + "','" + data_angajarii_formatata + "' ,'" + data_nastere_formatata + "','" + cnp + "','" + SerieNrBuletin + "','" + nr_telefon + "',null,0,'" + zileconcediuramase + "','" + IdManager + "','" + salariu + "','" + 1 + "','" + IdEchipa + "')";

            Globals.executeNonQuery(sqlText);


            


            this.Close();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
