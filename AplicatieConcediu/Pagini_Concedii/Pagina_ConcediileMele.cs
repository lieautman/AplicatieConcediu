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

        private void Pagina_ConcediileMele_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("select * from Concediu", out conn);


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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
