using System;
using System.Collections.Generic;

namespace XD.Models
{
    public partial class Angajat
    {
        public Angajat()
        {
        }

        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Prenume { get; set; } 
        public string Email { get; set; }
        public string Parola { get; set; }
        public DateTime? DataAngajarii { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Cnp { get; set; }
        public string SeriaNumarBuletin { get; set; }
        public string Numartelefon { get; set; }
        public byte[] Poza { get; set; }
        public bool? EsteAdmin { get; set; }
        public int? NumarZileConceiduRamase { get; set; }
        public int? ManagerId { get; set; }
        public decimal? Salariu { get; set; }
        public bool? EsteAngajatCuActeInRegula { get; set; }
        public int? IdEchipa { get; set; }
    }
}
