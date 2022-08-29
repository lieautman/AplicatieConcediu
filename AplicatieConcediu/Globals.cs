using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu
{
    static class Globals
    {
        private static string _connString = "Data Source=ts2112\\SQLEXPRESS; Initial Catalog=GameOfThrones; User ID=internship2022; Password=int; TrustServerCertificate=True; Integrated Security=False;";

        public static string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }
    }
}
