using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class AngajatiLista
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
       public AngajatiLista(string nume, string prenume)
        {
            Nume = nume;
            Prenume = prenume;

        }
    }
 

}
