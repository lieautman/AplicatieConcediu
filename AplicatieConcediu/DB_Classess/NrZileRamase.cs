using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class NrZileRamase
    {
        int Id { get; set; }
        public int NumarZileConceiduRamase { get; set; }


        public NrZileRamase(int id,int numarZileConceiduRamase)
        {
            this.Id = id;
            NumarZileConceiduRamase = numarZileConceiduRamase;
        }   
    }
}
