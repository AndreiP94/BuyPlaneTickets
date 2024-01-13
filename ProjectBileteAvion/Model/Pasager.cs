using System.ComponentModel.DataAnnotations;

namespace ProjectASPNet.Model
{
    public class Pasager
    {
        public Pasager()
        {
            Bilete = new List<Bilet>();
        }
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Numele trebuie să conțină doar litere.")]
        public string Nume { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Prenumele trebuie să conțină doar litere.")]
        public string Prenume { get; set; }
        public string NumarDocument { get; set; }

        [RegularExpression(@"^[^@\s]+@(gmail\.com|yahoo\.com|icloud\.com)$", ErrorMessage = "Doar adresele de email de la Gmail, Yahoo și iCloud sunt permise.")] public string Email { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Telefonul trebuie să conțină doar cifre.")]
        public string Telefon { get; set; }


        public List<Bilet> Bilete { get; set; }
    }
}
