using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicatieConcediu.DB_Classess
{
    internal class AfisareConcedii
    {
        /*
         *    var obConcediu = new Concediu();
                            var tipConcediu = dr.GetValue(1);
                            var dataInceput = dr.GetValue(2);
                            var dataSfarsit = dr.GetValue(3);
                            var inlocuitor = dr.GetValue(4);
                            var comentarii = dr.GetValue(5);
                            var angajat = dr.GetValue(7);*/

        public string IdConcediu { get; set; }
        public string NumeTipConcediu { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public string NumeInlocuitor { get; set; }
        public string Comentarii { get; set; }
        public string NumeAngajat { get; set; }

        public AfisareConcedii(string idConcediu, string numeTipConcediu, DateTime dataInceput, DateTime dataSfarsit, string numeInlocuitor, string comentarii, string numeAngajat)
        {
            IdConcediu = idConcediu;
            NumeTipConcediu = numeTipConcediu;
            DataInceput = dataInceput;
            DataSfarsit = dataSfarsit;
            NumeInlocuitor = numeInlocuitor;
            Comentarii = comentarii;
            NumeAngajat = numeAngajat;

        }

        public AfisareConcedii()
        {

        }
    }
}
