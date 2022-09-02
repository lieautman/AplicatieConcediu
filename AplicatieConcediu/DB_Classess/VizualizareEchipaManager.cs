using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class VizualizareEchipaManager
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int ManagerId { get; set; }  
        public int IdEchipa { get; set; }

        public VizualizareEchipaManager(string nume, string prenume, int managerId, int idEchipa)
        {
            Nume = nume;
            Prenume = prenume;
            ManagerId = managerId;
            IdEchipa = idEchipa;
        }   
    }
}
