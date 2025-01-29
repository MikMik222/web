
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Ney_Nemovitost.web.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Smlouva")]
    public class ModelSmlouva
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(najemnik))]
        public int idNajemnik { get; set; }
        public Najemnik ?najemnik { get;set; }
        [ForeignKey(nameof(User))]
        public int idVlastnik { get; set; }
        public bool aktivni { get; set; } = true;

        [ForeignKey(nameof(ModelNemovitost))]
        public int idNemovitost { get; set; }

        public DateOnly platnaOd { get; set; }
        public DateOnly platnaDo { get; set; }
        public string ?SrcToFile { get; set; }
    }
}
