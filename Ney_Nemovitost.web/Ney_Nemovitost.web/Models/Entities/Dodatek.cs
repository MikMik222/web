
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Dodatek")]
    public class Dodatek
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(typyDodatku))]
        public int idDodatku { get; set; }

        public TypyDodatku typyDodatku { get; set; }

        public string srcToPdf { get; set; }

        [ForeignKey(nameof(ModelSmlouva))]
        public int idSmlouva { get; set; }
        [ForeignKey(nameof(ModelNemovitost))]
        public int idNemovitost { get; set; }
        public DateOnly datumPlatnosti { get; set; }
    }
}
