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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace AplicatieConcediu
{
    public partial class Pagina_ConcediileMele : Form
    {
        private List<Concediu> listaConcediu = new List<Concediu>();
        public Pagina_ConcediileMele()
        {
            InitializeComponent();
        }

        //calculare/aducere de zile concediu/zile ramase de concediu
        private int numarZileConceiduRamase = 0;
        //load legacy
        private void Pagina_ConcediileMele_LoadLegacy(object sender, EventArgs e)
        {
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }


            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select * from Concediu c join Angajat a on a.Id = c.AngajatId where a.Email = '"+ emailFolositLaSelect + "'", out conn);


            while (reader.Read())
            {
                int id = (int)reader["id"];
                int tipConcediuId = (int)reader["TipConcediuId"];
                DateTime dataInceput = (DateTime)reader["DataInceput"];
                DateTime dataSfarsit = (DateTime)reader["dataSfarsit"];
                int inlocuitorId = (int)reader["InlocuitorId"];
                string comentarii = (string)reader["Comentarii"];
                int stareConcediuId = (int)reader["StareConcediuId"];
                int angajatId = (int)reader["AngajatId"];

                Concediu concediu = new Concediu( id,  tipConcediuId,  dataInceput,  dataSfarsit,  inlocuitorId,  comentarii,  stareConcediuId,  angajatId);


                listaConcediu.Add(concediu);
            }
            reader.Close();

            dataGridView1.DataSource = listaConcediu;

            conn.Close();


            //incarcare label cu nr zile de concediu ramase
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Id, NumarZileConceiduRamase from Angajat where Email = '" + emailFolositLaSelect + "'", out conn1);

            while (reader1.Read())
            {
                Globals.IdUserActual1 = (int)reader1["Id"];
                numarZileConceiduRamase += (int)reader1["NumarZileConceiduRamase"];

            }
            reader1.Close();
            conn1.Close();
            label7.Text = numarZileConceiduRamase.ToString();


            label6.Text = (21 - numarZileConceiduRamase).ToString();
        }
        //load new
        private void Pagina_ConcediileMele_Load(object sender, EventArgs e)
        {
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            string emailFolositLaSelect;
            if (Globals.EmailUserViewed != "")
            {
                emailFolositLaSelect = Globals.EmailUserViewed;
            }
            else
            {
                emailFolositLaSelect = Globals.EmailUserActual;
            }


            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select * from Concediu c join Angajat a on a.Id = c.AngajatId where a.Email = '" + emailFolositLaSelect + "'", out conn);


            while (reader.Read())
            {
                int id = (int)reader["id"];
                int tipConcediuId = (int)reader["TipConcediuId"];
                DateTime dataInceput = (DateTime)reader["DataInceput"];
                DateTime dataSfarsit = (DateTime)reader["dataSfarsit"];
                int inlocuitorId = (int)reader["InlocuitorId"];
                string comentarii = (string)reader["Comentarii"];
                int stareConcediuId = (int)reader["StareConcediuId"];
                int angajatId = (int)reader["AngajatId"];

                Concediu concediu = new Concediu(id, tipConcediuId, dataInceput, dataSfarsit, inlocuitorId, comentarii, stareConcediuId, angajatId);


                listaConcediu.Add(concediu);
            }
            reader.Close();

            dataGridView1.DataSource = listaConcediu;

            conn.Close();


            //incarcare label cu nr zile de concediu ramase
            SqlConnection conn1 = new SqlConnection();
            SqlDataReader reader1 = Globals.executeQuery("Select Id, NumarZileConceiduRamase from Angajat where Email = '" + emailFolositLaSelect + "'", out conn1);

            while (reader1.Read())
            {
                Globals.IdUserActual1 = (int)reader1["Id"];
                numarZileConceiduRamase += (int)reader1["NumarZileConceiduRamase"];

            }
            reader1.Close();
            conn1.Close();
            label7.Text = numarZileConceiduRamase.ToString();


            label6.Text = (21 - numarZileConceiduRamase).ToString();
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
