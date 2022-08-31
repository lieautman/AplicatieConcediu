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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Adaugare_Angajat : Form
    {
        private List<AngajatiListaPentruAngajare> AngajatiLista = new List<AngajatiListaPentruAngajare>();
        public Adaugare_Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Adaugare_Angajat_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select Nume, Prenume, Email, Parola,DataNasterii,CNP,SeriaNumarBuletin,Numartelefon from  Angajat", out conn);


            while (reader.Read())
            {
                string nume = (string)reader["Nume"];
                string prenume = (string)reader["Prenume"];
                string email = (string)reader["Email"];
                string parola = (string)reader["Parola"];
                DateTime datanasterii = (DateTime)reader["DataNasterii"];
                string Cnp = (string)reader["CNP"];
                string serianumarbuletin = (string)reader["SeriaNumarBuletin"];
                string numartelefon = (string)reader["Numartelefon"];


                AngajatiListaPentruAngajare angajati = new AngajatiListaPentruAngajare(nume, prenume, email, parola, datanasterii, Cnp, serianumarbuletin, numartelefon);

                AngajatiLista.Add(angajati);
            }
            reader.Close();

            dataGridView1.DataSource = AngajatiLista;

            conn.Close();
            DataGridViewButtonColumn buton = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
            buton.Name = "Actiuni";
            buton.HeaderText = "Actiuni";
            buton.Text = "Adauga Angajat";
            buton.Tag = (Action<AngajatiListaPentruAngajare>)ClickHandler;
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
                var clickHandler = (Action<AngajatiListaPentruAngajare>)grid.Columns[e.ColumnIndex].Tag;
                var person = (AngajatiListaPentruAngajare)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(person);
            }
        }
        private void ClickHandler(AngajatiListaPentruAngajare a)
        {
            Form Angajare = new Angajare();
            this.Hide();
            Angajare.ShowDialog();
            this.Show();



        }

    }

}


