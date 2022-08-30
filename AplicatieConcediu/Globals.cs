﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.Data.SqlClient;

namespace AplicatieConcediu
{
    static class Globals
    {
        //string-ul pentru conectare la baza de date
        private static string _connString = "Data Source=ts2112\\SQLEXPRESS; Initial Catalog=GameOfThrones; User ID=internship2022; Password=int; TrustServerCertificate=True; Integrated Security=False;";
        //functii pe acel string
        public static string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        //functii pentru accesare baza de date
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
        public static SqlDataReader executeQuery(string sqlCommand)
        {
            SqlConnection connection = new SqlConnection(Globals._connString);

            connection.Open();
            string sqlText = sqlCommand;

            SqlCommand command = new SqlCommand(sqlText, connection);
            SqlDataReader reader = command.ExecuteReader();


            connection.Close();
            return reader;
        }

    }
}