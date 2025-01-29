
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("HistorieCen")]
    public class HistorieCen
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(ModelNemovitost))]
        public int idNemovitosti { get; set; }
        [ForeignKey(nameof(moznostiSluzeb))]
        public int idSluzby { get; set; }
        public MoznostiSluzeb moznostiSluzeb { get; set; }
        public DateOnly cenaPlatnaOd { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public double cena { get; set; }
    }
}
