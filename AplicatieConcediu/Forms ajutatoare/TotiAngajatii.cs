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

namespace AplicatieConcediu
{
    public partial class TotiAngajatii : Form
    {
        public TotiAngajatii()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "SELECT * FROM Angajat WHERE Id =1";
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery(query, out connection);
           // dataGridView1 = reader["Angajat"];

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
