using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class ClasaJoinAngajatiConcediiTip
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string ManagerNumePrenume { get; set; }  
        public string NumeEchipa { get; set; }


        public ClasaJoinAngajatiConcediiTip(string nume, string prenume, string email, string managerNumePrenume, string numeEchipa)
        {
            Nume = nume;
            Prenume = prenume;
            Email = email;
            ManagerNumePrenume = managerNumePrenume;
            NumeEchipa = numeEchipa;
        }
    }


}
