
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("KostrukceNemovitosti")]
    public class KostrukceNemovitosti
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Konstrukce { get; set; }
    }
}
