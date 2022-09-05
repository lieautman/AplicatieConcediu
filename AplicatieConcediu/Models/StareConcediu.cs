using System;
using System.Collections.Generic;

namespace XD.Models
{
    public partial class StareConcediu
    {
        public StareConcediu()
        {
            Concedius = new HashSet<Concediu>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Cod { get; set; } 

        public virtual ICollection<Concediu> Concedius { get; set; }
    }
}
