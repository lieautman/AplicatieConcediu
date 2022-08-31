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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasaJoinAngajatiConcediiTip a =listaAngajati[e.RowIndex];

            Globals.EmailUserViewed = a.Email;


            Form pagina_profil = new Pagina_Profil_Angajat();
            this.Hide();
            pagina_profil.ShowDialog();
            this.Show();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TotiAngajatii_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput, c.DataSfarsit\r\nfrom Concediu c\r\nright join Angajat a on a.Id=c.AngajatId\r\nleft join TipConcediu tc on tc.Id=c.TipConcediuId ", out conn);


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


                ClasaJoinAngajatiConcediiTip angajat = new ClasaJoinAngajatiConcediiTip(nume, prenume, email,nume_tip_concediu,data_sfarsit,data_inceput);


                listaAngajati.Add(angajat);
            }
            reader.Close();

            dataGridView1.DataSource = listaAngajati;

            conn.Close();
        }
    }
}
