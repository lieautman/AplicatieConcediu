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



namespace AplicatieConcediu
{
    public partial class TotiAngajatii : Form

    {
        private List<ClasaJoinAngajatiConcediiTip> listaAngajati = new List<ClasaJoinAngajatiConcediiTip>();
        public TotiAngajatii()
        {
            InitializeComponent();

        }

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

        private void TotiAngajatii_Load(object sender, EventArgs e)
        {

            string sqlCommand;
            if (Globals.IdEchipa == 0) {
                sqlCommand = "select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput,a.ManagerId, c.DataSfarsit from Concediu c right join Angajat a on a.Id=c.AngajatId left join TipConcediu tc on tc.Id=c.TipConcediuId ";
            }
            else
            {
                sqlCommand = "select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput,a.ManagerId, c.DataSfarsit from Concediu c right join Angajat a on a.Id=c.AngajatId left join TipConcediu tc on tc.Id=c.TipConcediuId where a.IdEchipa='"+Globals.IdEchipa+"'";
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

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.GridColor = Color.FromArgb(249, 80, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
