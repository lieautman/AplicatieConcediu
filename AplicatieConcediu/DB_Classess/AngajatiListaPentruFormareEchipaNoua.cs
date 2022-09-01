using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConcediu.DB_Classess
{
    internal class AngajatiListaPentruFormareEchipaNoua
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public DateTime DataAngajarii { get; set; }
        public DateTime DataNasterii { get; set; }
        public string CNP { get; set; }
        public int IdEchipa { get; set; }
     

        public AngajatiListaPentruFormareEchipaNoua(string nume, string prenume, string email, DateTime dataAngajarii, DateTime dataNasterii, string cNP,int idEchipa)
        {
            Nume = nume;
            Prenume = prenume;
            Email = email;
            DataAngajarii = dataAngajarii;
            DataNasterii = dataNasterii;
            CNP = cNP;
            IdEchipa = idEchipa;
          
        }   
    }
}
