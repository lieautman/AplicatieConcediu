using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace AplicatieConcediu
{
    static class Globals
    {
        public static Random codVerificare = new Random();

        //string-ul pentru conectare la baza de date
        public static string _connString = "Data Source=ts2112\\SQLEXPRESS; Initial Catalog=GameOfThrones; User ID=internship2022; Password=int; TrustServerCertificate=True; Integrated Security=False;";
        //functii pe acel string
        public static string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        //angajatul curent
        public static XD.Models.Angajat _angajatLogatInAplicatie=null;
        public static XD.Models.Angajat AngajatLogatInAplicatie
        {
            get { return _angajatLogatInAplicatie; }
            set { _angajatLogatInAplicatie = value; }
        }


        //email-ul userului actual
        public static string _emailUserActual="";
        public static string EmailUserActual
        {
            get { return _emailUserActual; }
            set { _emailUserActual = value; }
        }

        //angajat spre aprobare
        public static string _emailUserAprobare = "";
        public static string EmailUserAprobare
        {
            get { return _emailUserAprobare; }
            set { _emailUserAprobare = value; }
        }

        //esteAdmin
        public static bool _isAdmin = false;
        public static bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        //esteManager
        public static bool _isManager = false;
        public static bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; }
        }

        //id-ul concediului din Gris
        public static string _idConcediuInAprobare = "";
        public static string IdConcediuInAprobare
        {
            get { return _idConcediuInAprobare; }
            set { _idConcediuInAprobare = value; }
        }

        //id-ul echipei selectate din Pagina cu toate echipele
        public static int _idEchipa = 0;
        public static int IdEchipa
        {
            get { return _idEchipa; }
            set { _idEchipa = value; }
        }

        //emial-ul utilizatorului profilului vizualizat
        public static string _emailUserViewed="";
        public static string EmailUserViewed
        {
            get { return _emailUserViewed; }
            set { _emailUserViewed = value; }
        }

        public static int _idUserActual1=0;
        public static int IdUserActual1
        {
            get { return _idUserActual1; }
            set { _idUserActual1 = value; }

        }

        //emailul managerului selectat din grid
        public static string _emailManager="";
        public static string EmailManager
        {
            get { return _emailManager; }
            set { _emailManager = value; }


        }

        //id ul angajatului selectat din grid
        public static string _idAngajatSelectat ="";
        public static string IdAngajatSelectat
        {
            get { return _idAngajatSelectat; }
            set { _idAngajatSelectat = value; }
        }

        //emial-ul angajatului cu acteNeinregula inca
        public static string _emailAngajatCuActeNeinregula = "";
        public static string EmailAngajatCuActeNeinregula
        {
            get { return _emailAngajatCuActeNeinregula; }
            set { _emailAngajatCuActeNeinregula = value; }
        }

        public static int? _idManager;
        public static int? IdManager
        {
            get { return _idManager; }
            set { _idManager = value; }
        }
        //id ul echipei selectate din combobox in pagina de formare echipa angajat promovat
        public static int _IdEchipaSelectata;
        public static int IdEchipaSelectata
        {
            get { return _IdEchipaSelectata; }
            set { _IdEchipaSelectata = value; }
        }




        //functii pentru accesare baza de date (legacy)
        public static int executeNonQuery(string sqlCommand)
        {
            SqlConnection connection = new SqlConnection(Globals._connString);

            connection.Open();
            string sqlText = sqlCommand;

            SqlCommand command = new SqlCommand(sqlText, connection);
            command.ExecuteNonQuery();


            connection.Close();
            return 1;
        }
        public static SqlDataReader executeQuery(string sqlCommand, out SqlConnection conn)
        {
            SqlConnection connection = new SqlConnection(Globals._connString);

            connection.Open();
            string sqlText = sqlCommand;

            SqlCommand command = new SqlCommand(sqlText, connection);
            SqlDataReader reader = command.ExecuteReader();

            


            conn = connection;
            return reader;
        }
    }
}
