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
using AplicatieConcediu.Pagini_Profil;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using AplicatieConcediu.Pagini_Actiuni;

namespace AplicatieConcediu
{
    public partial class TotiAngajatii : Form

    {
        private List<ClasaJoinAngajatiConcediiTip> listaAngajati = new List<ClasaJoinAngajatiConcediiTip>();
        public TotiAngajatii()
        {
            InitializeComponent();

        }

        //deschide profilul uni angajat la click pe o celula din data grid view
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClasaJoinAngajatiConcediiTip a = listaAngajati[e.RowIndex];

                if (a.Email != Globals.EmailUserActual)
                    Globals.EmailUserViewed = a.Email;


                Form pagina_profil = new Pagina_Profil_Angajat();
                this.Hide();
                pagina_profil.ShowDialog();
                this.Show();
            }
        }

        //incarcare date angajati
        private void TotiAngajatii_Load(object sender, EventArgs e)
        {
            

            string sqlCommand;
            if (Globals.IdEchipa == 0)
            {
                sqlCommand = "select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput,a.ManagerId, c.DataSfarsit from Concediu c right join Angajat a on a.Id=c.AngajatId left join TipConcediu tc on tc.Id=c.TipConcediuId ";
            }
            else
            {
                sqlCommand = "select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput,a.ManagerId, c.DataSfarsit from Concediu c right join Angajat a on a.Id=c.AngajatId left join TipConcediu tc on tc.Id=c.TipConcediuId where a.IdEchipa='" + Globals.IdEchipa + "'";
            }

            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery(sqlCommand, out conn);


            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                string nume_tip_concediu;
                if (reader[3] != DBNull.Value)
                    nume_tip_concediu = (string)reader[3];
                else
                    nume_tip_concediu = "";
                DateTime data_inceput;
                if (reader[3] != DBNull.Value)
                    data_inceput = (DateTime)reader["DataInceput"];
                else
                    data_inceput = new DateTime();
                DateTime data_sfarsit;
                if (reader[3] != DBNull.Value)
                    data_sfarsit = (DateTime)reader["DataSfarsit"];
                else
                    data_sfarsit = new DateTime();

                int managerId;
                if (reader["ManagerId"] != DBNull.Value)
                    managerId = (int)reader["ManagerId"];
                else
                    managerId = 0;
               


                ClasaJoinAngajatiConcediiTip angajat = new ClasaJoinAngajatiConcediiTip(nume, prenume, email,nume_tip_concediu,data_sfarsit,data_inceput,managerId);


                listaAngajati.Add(angajat);
            }

            reader.Close();
            conn.Close();

            dataGridView1.DataSource = listaAngajati;

            
            dataGridView1.Columns["NumeTipConcediu"].HeaderText = "Tipul Concediului";
            dataGridView1.Columns["DataInceput"].HeaderText = "Data de inceput";
            dataGridView1.Columns["DataSfarsit"].HeaderText = "Data de sfarsit";
            dataGridView1.Columns["ManagerId"].HeaderText = "Managerul";

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.GridColor = Color.FromArgb(249, 80, 0);
        }



        //butoane
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.IdEchipa = 0;
            this.Close();
        }

        

       

        int count = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            count++;

            if(count%2!=0)
            {
                button1.Show();
                button8.Show();
                button9.Show();
                button10.Show();
                if (Globals.IsAdmin == true || Globals.IdManager == null)
                {
                button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();
                

                }
                
            }
            else
            {
                button1.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form adaugare_angajat = new Aprobare_Angajare();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            this.Hide();
            adaugareangajatnou.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pagina_Profil_Angajat form = new Pagina_Profil_Angajat();
            Globals.EmailUserViewed = "";
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
    }
}
