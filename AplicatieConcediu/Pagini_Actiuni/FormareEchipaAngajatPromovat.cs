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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicatieConcediu.Pagini_Actiuni
{
    public partial class FormareEchipaAngajatPromovat : Form
    {
        private List<Angajat> listaAngajati = new List<Angajat>();
        public FormareEchipaAngajatPromovat()
        {
            InitializeComponent();
        }

        private void FormareEchipaAngajatPromovat_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataReader reader = Globals.executeQuery("Select * from Angajat where idEchipa=null ", out conn);
            while (reader.Read())
            {
                
            }
         //   Angajat angajat = new Angajat(nume, prenume, email, nume_tip_concediu, data_sfarsit, data_inceput);


           // listaAngajati.Add(angajat);
            conn.Close();
        }
    }
}
