using System;
using System.Collections.Generic;

namespace XD.Models
{
    public partial class Echipa
    {
        public Echipa()
        {
            Angajats = new HashSet<Angajat>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Descriere { get; set; } 
        public byte[] Poza { get; set; }

        public virtual ICollection<Angajat> Angajats { get; set; }
    }
}
