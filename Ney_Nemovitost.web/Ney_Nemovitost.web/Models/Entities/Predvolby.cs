
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Predvolby")]
    public class Predvolby
    {
        [Key]
        public int ID { get; set; }
        public string NameCountry { get; set; }
        public int predvolba { get; set; }
    }
}
