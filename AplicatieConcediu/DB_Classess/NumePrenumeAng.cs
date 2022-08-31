using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class NumePrenumeAng
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public NumePrenumeAng(string nume, string prenume)
        {
            Nume = nume;
            Prenume = prenume;
        }
    }
}
