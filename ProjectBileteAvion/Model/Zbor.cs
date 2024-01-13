using System.ComponentModel.DataAnnotations;

namespace ProjectASPNet.Model
{
    public class Zbor
    {
        public Zbor()
        {
            Bilete = new List<Bilet>();
        }
        public int ID { get; set; }
        public int DestinatieID { get; set; }
        public DateTime DataOraPlecare { get; set; }
        public DateTime DataOraSosire { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Statusul trebuie să conțină doar litere.")]
        public string Status { get; set; }

        public Destinatie Destinatie { get; set; }
        public List<Bilet> Bilete { get; set; }
    }
}
