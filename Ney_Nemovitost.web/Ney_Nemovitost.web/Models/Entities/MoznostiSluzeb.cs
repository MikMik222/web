
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("MoznostiSluzeb")]
    public class MoznostiSluzeb
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NazevSluzby { get; set; }
    }
}
