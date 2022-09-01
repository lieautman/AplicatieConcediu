using AplicatieConcediu.DB_Classess;
using System;

namespace AplicatieConcediu.Pagini_Actiuni
{
    internal class AngajatiListaPentruAngajare
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Cnp { get; set; }
        public string SeriaNumarBuletin { get; set; }
        public string Numartelefon { get; set; }

        public AngajatiListaPentruAngajare(string nume, string prenume, string email, string parola,  DateTime dataNasterii, string CNP, string seriaNumarBuletin, string numartelefon )

        {

            Nume = nume;
            Prenume = prenume;
            Email = email;
            Parola = parola;
            DataNasterii = dataNasterii;
            Cnp = CNP;
            SeriaNumarBuletin = seriaNumarBuletin;
            Numartelefon = numartelefon;

        }

        internal static void Add(ClasaJoinAngajatiConcediiTip angajat)
        {
            throw new NotImplementedException();
        }

        internal static void Add(AngajatiListaPentruAngajare angajati)
        {
            throw new NotImplementedException();
        }
    }
}