namespace AplicatieConcediu.Pagini_Actiuni
{
    internal class Echipe
    {   int id { get; set; }

        public string Nume { get; set; }

        public Echipe(int Id, string nume)
        {
            this.id = Id;
            Nume = nume;
           }

    }
}