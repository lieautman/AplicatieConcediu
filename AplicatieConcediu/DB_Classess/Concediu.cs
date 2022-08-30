using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu
{
    internal class Concediu
    {
        public int id { get; set; }
        public int tipConcediuId { get; set; }
        public DateTime dataInceput { get; set; }
        public DateTime dataSfarsit { get; set; }
        public int inlocuitorId { get; set; }
        public string comentarii { get; set; }
        public int stareConcediuId {get; set;}
        public int angajatId { get; set; }

        public Concediu (int id, int tipConcediuId, DateTime dataInceput, DateTime dataSfarsit, int inlocuitorId, string comentarii, int stareConcediuId, int angajatId)
        {
            this.id = id;
            this.tipConcediuId = tipConcediuId;
            this.dataInceput = dataInceput;
            this.dataSfarsit = dataSfarsit;
            this.inlocuitorId = inlocuitorId;
            this.comentarii = comentarii;
            this.stareConcediuId = stareConcediuId;
            this.angajatId = angajatId;
        }   
       
    }
}
