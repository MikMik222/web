
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("AdresaVlastniku")]
    public class ModelAdresa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UliceACisloPop { get; set; }
        [Required]
        [StringLength(50)]
        public string Obec { get; set; }

        [Required]
        [StringLength(7)]
        public string Psc { get; set; }
    }
}
