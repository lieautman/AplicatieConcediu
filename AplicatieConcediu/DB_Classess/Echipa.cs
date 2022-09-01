using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class Echipa
    {
       public int Id { get; set; }
       public string Nume { get; set; }

  
      


        public Echipa(int id,string nume)
        {
            this.Id = id;
            Nume = nume;
        }

        public Echipa()
        {
        }
    }
}
