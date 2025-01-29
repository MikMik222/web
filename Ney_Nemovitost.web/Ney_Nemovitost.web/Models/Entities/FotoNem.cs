
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("FotoNem")]
    public class FotoNem
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public virtual IFormFile Image { get; set; }
        [Required]
        [StringLength(255)]
        public string ImageSrc { get; set; }

        [ForeignKey(nameof(modelNemovitost))]
        public int Id_Nemo { get; set; }
        public ModelNemovitost modelNemovitost { get; set; }
    }
}
