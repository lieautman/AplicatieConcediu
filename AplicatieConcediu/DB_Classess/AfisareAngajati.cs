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
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Cnp { get; set; }
        public string Numartelefon { get; set; }
        public int ManagerId { get; set; }

        public AfisareAngajati(int id, string nume, string prenume, string email, DateTime dataNasterii,string cnp, string numartelefon, int managerId)
        {
            Id = id;
            Nume = nume;
            Prenume = prenume;
            Email = email;
            DataNasterii = dataNasterii;
            Cnp = cnp;
            Numartelefon = numartelefon;
            ManagerId = managerId;
        }   

        public AfisareAngajati()
        {

        }
    }
}
