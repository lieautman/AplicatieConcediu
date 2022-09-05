using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace XD.Models
{
    public partial class TipConcediu
    {
        public TipConcediu()
        {
            Concedius = new HashSet<Concediu>();
        }
        
        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Cod { get; set; } 
        public virtual ICollection<Concediu> Concedius { get; set; }
    }
}
