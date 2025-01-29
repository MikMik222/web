
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("DispoziceNemovitosti")]
    public class DispoziceNemovitosti
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Dispozice { get; set; }
    }
}
