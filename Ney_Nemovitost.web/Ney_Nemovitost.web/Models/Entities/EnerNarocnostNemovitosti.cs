
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("EnerNarocnostNemovitosti")]
    public class EnerNarocnostNemovitosti
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string EnerNárocnost { get; set; }
    }
}
