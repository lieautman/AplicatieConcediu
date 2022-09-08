using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class AfisareAngajati
    {
       
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Numartelefon { get; set; }
        public string NumeEchipa { get; set; }
   

        public AfisareAngajati( string nume, string prenume, string email, DateTime dataNasterii, string numartelefon, string numeEchipa)
        {
       
            Nume = nume;
            Prenume = prenume;
            Email = email;
            DataNasterii = dataNasterii;
            Numartelefon = numartelefon;
            NumeEchipa = numeEchipa;
         
        }   

        public AfisareAngajati()
        {

        }
    }
}
