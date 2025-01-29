
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("OptionNemovitost")]
    public class OptionNemovitost
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Volba { get; set; }
        public string VolbaJinyPad { get; set; }
    }
}
