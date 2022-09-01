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
using AplicatieConcediu.DB_Classess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class Aprobare_Concediu : Form
    {
        private List<AfisareConcedii> listaConcedii = new List<AfisareConcedii>();
        public Aprobare_Concediu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Aprobare_Concediu_Load(object sender, EventArgs e)
        {

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {


                    string query = string.Format(" select c.id, tc.Nume, c.DataInceput, c.DataSfarsit, a2.Nume, c.Comentarii,  a.Nume  from Concediu c\r\n left join TipConcediu tc on tc.Id = c.TipConcediuId\r\nleft join Angajat a2 on a2.Id = c.InlocuitorId\r\nleft join Angajat a on a.Id = c.AngajatId\r\nwhere c.StareConcediuId ='" + 3 + "'");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var idConcediu = dr.GetValue(0).ToString();
                            var tipConcediu = dr.GetValue(1).ToString();
                            var dataInceput = (DateTime)dr.GetValue(2);
                            var dataSfarsit = (DateTime)dr.GetValue(3);
                            var inlocuitor = dr.GetValue(4).ToString();
                            var comentarii = dr.GetValue(5).ToString();
                            var angajat = dr.GetValue(6).ToString();

                            AfisareConcedii concediu = new AfisareConcedii(idConcediu, tipConcediu, dataInceput, dataSfarsit, inlocuitor, comentarii, angajat);

                            listaConcedii.Add(concediu);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();
                    conn.Close();

                    dataGridView1.DataSource = listaConcedii;

                    DataGridViewButtonColumn butonAprobare = new DataGridViewButtonColumn();
                    butonAprobare.HeaderText = "Aprobare";
                    butonAprobare.Text = "Aprobare ";
                    butonAprobare.Tag = (Action<AfisareConcedii>)ClickHandlerAprobare;
                    butonAprobare.UseColumnTextForButtonValue = true;

                    DataGridViewButtonColumn butonRespinge = new DataGridViewButtonColumn();
                    butonRespinge.HeaderText = "Respinge";
                    butonRespinge.Text = "Respingere ";
                    butonRespinge.Tag = (Action<AfisareConcedii>)ClickHandlerRespingere;
                    butonRespinge.UseColumnTextForButtonValue = true;

                    DataGridViewButtonColumn butonEditare = new DataGridViewButtonColumn(); //buton pe fiecare inregistrare
                    butonEditare.HeaderText = "Editare";
                    butonEditare.Text = "Editare";
                    butonEditare.Tag = (Action<AfisareConcedii>)ClickHandlerEditare;
                    butonEditare.UseColumnTextForButtonValue = true;
                   


                    this.dataGridView1.Columns.Add(butonAprobare);
                    this.dataGridView1.Columns.Add(butonRespinge);
                    this.dataGridView1.Columns.Add(butonEditare);
                    dataGridView1.CellContentClick += Buton_CellContentClick;



                }


            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void ClickHandlerAprobare(AfisareConcedii a)
        {
            Globals.IdConcediuInAprobare = a.IdConcediu;

            try
            { //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" UPDATE Concediu  SET StareConcediuId ='" + 1 + "'WHERE id = '" + Globals.IdConcediuInAprobare + "'  ");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    Globals.executeNonQuery(query);

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
            Aprobare_Concediu form = new Aprobare_Concediu();
            this.Hide();
            this.Close();
            form.ShowDialog();
            


        }

        private void ClickHandlerRespingere(AfisareConcedii a)
        {
            Globals.IdConcediuInAprobare = a.IdConcediu;

            try
            { //sql connection object
                using (SqlConnection conn = new SqlConnection(Globals.ConnString))
                {
                    string query = string.Format(" UPDATE Concediu  SET StareConcediuId ='" + 2 + "'WHERE id = '" + Globals.IdConcediuInAprobare + "' ");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    //execute the SQLCommand
                    Globals.executeNonQuery(query);

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");
                    //check if there are records
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
            Aprobare_Concediu form = new Aprobare_Concediu();
            this.Hide();
            this.Close();
            form.ShowDialog();


        }
        private void ClickHandlerEditare(AfisareConcedii a)
        {


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
                var clickHandler = (Action<AfisareConcedii>)grid.Columns[e.ColumnIndex].Tag;
                var concediu = (AfisareConcedii)grid.Rows[e.RowIndex].DataBoundItem;

                clickHandler(concediu);
            }
        }
    }
}
