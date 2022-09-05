using AplicatieConcediu.DB_Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicatieConcediu;
using AplicatieConcediu.DB_Classess;
using System.Data.SqlClient;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Promovare_Angajat : Form
    {
        
        private List<ClasaJoinAngajatiConcediiTip> listaAngajati = new List<ClasaJoinAngajatiConcediiTip>();
  

        public Promovare_Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Promovare_Angajat_Load(object sender, EventArgs e)
        {
            //join angajati, concedii si tip concediu, afisare in grid pt toti angajatii(fara manageri/admini)
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select a.Nume, a.Prenume, a.Email, tc.Nume,c.DataInceput,a.ManagerId, c.DataSfarsit\r\nfrom Concediu c\r\nright join Angajat a on a.Id=c.AngajatId\r\nleft join TipConcediu tc on tc.Id=c.TipConcediuId where ManagerId is not null", out conn);


            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                string nume_tip_concediu = "";
                if (reader[3]!=DBNull.Value)
                    nume_tip_concediu = (string)reader[3];
                DateTime data_inceput = new DateTime();
                if (reader[3] != DBNull.Value)
                    data_inceput = (DateTime)reader["DataInceput"];
                DateTime data_sfarsit = new DateTime();
                if (reader[3] != DBNull.Value)
                     data_sfarsit = (DateTime)reader["DataSfarsit"];
               int managerId = (int)reader["ManagerId"];


                ClasaJoinAngajatiConcediiTip angajat = new ClasaJoinAngajatiConcediiTip(nume, prenume, email, nume_tip_concediu, data_sfarsit, data_inceput,managerId);


                listaAngajati.Add(angajat);
            }
            reader.Close();

            dataGridView1.DataSource = listaAngajati;

            conn.Close();


            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Actiuni";
            buton.HeaderText = "Actiuni";
            buton.Text = "Promoveaza";
            buton.Tag = (Action<ClasaJoinAngajatiConcediiTip>)ClickHandler;
            buton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(buton);
            dataGridView1.CellContentClick += Buton_CellContentClick;

        }

        private void Buton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
            {
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                var clickHandler = (Action<ClasaJoinAngajatiConcediiTip>)grid.Columns[e.ColumnIndex].Tag;
                var person = (ClasaJoinAngajatiConcediiTip)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(person);
            }
        }
        private void ClickHandler(ClasaJoinAngajatiConcediiTip a)
        {
            Globals.EmailManager = a.Email;
            FormareEchipaAngajatPromovat form = new FormareEchipaAngajatPromovat();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)


        {
    





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
