using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu
{
    public class Angajat
    {
        public int id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public DateTime? DataAngajarii { get; set; }
        public DateTime DataNasterii { get; set; }
        public string CNP { get; set; }
        public string SeriaNumarBuletin { get; set; }
        public string Numartelefon { get; set; }
        public string Poza { get; set; }
        public bool? EsteAdmin { get; set; }
        public int? ManagerId { get; set; }
        public float? Salariu { get; set; }
        public bool? EsteAngajatCuActeInRegula { get; set;}
        public int? idEchipa { get; set; }
        public string NumeComplet { get { return Nume +" "+ Prenume; }  }
        public int? NrZileConcediuRamase { get; set; }
        public Angajat(int id, string nume, string prenume, string email, string parola, string v, DateTime dataAngajarii, DateTime dataNasterii, string cNP, string seriaNumarBuletin, string numartelefon, string poza, bool esteAdmin, int managerId, float salariu, bool esteAngajatCuActeInRegula,int nrZileConcediuRamase, int idEchipa)
        {
            this.id = id;
            this.Nume = nume;
            Prenume = prenume;
            Email = email;
            Parola = parola;
            DataAngajarii = dataAngajarii;
            DataNasterii = dataNasterii;
            CNP = cNP;
            SeriaNumarBuletin = seriaNumarBuletin;
            Numartelefon = numartelefon;
            Poza = poza;
            EsteAdmin = esteAdmin;
            ManagerId = managerId;
            Salariu = salariu;
            EsteAngajatCuActeInRegula = esteAngajatCuActeInRegula;
            NrZileConcediuRamase = nrZileConcediuRamase;
            this.idEchipa = idEchipa;
        }

        public Angajat()
        {

        }
    }
}
