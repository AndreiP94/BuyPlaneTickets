namespace ProjectASPNet.Model
{
    public class Bilet
    {
        public int ID { get; set; }
        public int ZborID { get; set; }
        public int PasagerID { get; set; }
        public string Clasa { get; set; }
        public decimal Pret { get; set; }


        public Zbor Zbor { get; set; }
        public Pasager Pasager { get; set; }
    }
}
