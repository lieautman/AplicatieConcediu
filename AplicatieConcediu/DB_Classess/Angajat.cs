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
        public DateTime DataAngajarii { get; set; }
        public DateTime DataNasterii { get; set; }
        public string CNP { get; set; }
        public string SeriaNumarBuletin { get; set; }
        public string Numartelefon { get; set; }
        public string Poza { get; set; }
        public int EsteAdmin { get; set; }
        public int ManagerId { get; set; }
        public float Salariu { get; set; }
        public int EsteAngajatCuActeInRegula { get; set;}
        public string NumeComplet { get { return Nume +" "+ Prenume; }  }

        public Angajat(int id, string nume, string prenume, string email, string parola, DateTime dataAngajarii, DateTime dataNasterii, string cNP, string seriaNumarBuletin, string numartelefon, string poza, int esteAdmin, int managerId, float salariu, int esteAngajatCuActeInRegula)
        {
            this.id = id;
            Nume = nume;
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
        }

        public Angajat()
        {

        }
    }
}
