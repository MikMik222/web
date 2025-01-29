
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("TypyDodatku")]
    public class TypyDodatku
    {
        [Key]
        public int Id { get; set; }
        public string TypDodatku { get; set; }
    }
}
