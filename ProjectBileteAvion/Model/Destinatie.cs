using System.ComponentModel.DataAnnotations;

namespace ProjectASPNet.Model
{
    public class Destinatie
    {
        public Destinatie()
        {
            Zboruri = new List<Zbor>();
        }
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Numele trebuie să conțină doar litere.")]
        public string Nume { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tara trebuie să conțină doar litere.")]
        public string Tara { get; set; }

        public string Aeroport { get; set; }

        public List<Zbor> Zboruri { get; set; }
    }
}
