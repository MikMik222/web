
using Ney_Nemovitost.web.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Najemnik")]
    public class Najemnik
    {
        public DateOnly datumNarozeni { get; set; }
        public string email { get; set; }
        [ForeignKey(nameof(modelAdresa))]
        public int idAdresa { get; set; }
        public ModelAdresa ?modelAdresa { get; set; }
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(User))]
        public int vlastnikID { get; set; }

        [ForeignKey(nameof(predvolby))]
        public int idPredvolby { get; set; }
        public Predvolby ?predvolby { get; set; }

        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string rodneCislo { get; set; }
        public string telefon { get; set; }
    }
}
