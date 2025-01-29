
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Ney_Nemovitost.web.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Zavady")]
    public class ModelZavady
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(modelNemovitost))]
        public int idNemovitost { get; set; }
        
        public ModelNemovitost ?modelNemovitost { get; set; }

        [ForeignKey(nameof(majitel))]
        public int idmajitel { get; set; }
        public User ?majitel { get; set; }

        [ForeignKey(nameof(najemnik))]
        public int idNajemnik { get; set; }
        public Najemnik? najemnik { get;set; }

        public string popisZavady { get; set; }
        public string ?popisOpravy { get; set; }
        [Range(0,double.MaxValue)]
        public double cenaOpravy { get; set; }
        public string ?nazevOpravare { get; set; }


        public DateOnly datumNahlaseni { get; set; }
        [NotMapped]
        public DateTime datumNahlaseniFull { get; set; }
        public DateOnly datumOpravy { get; set; }
        [NotMapped]
        public DateTime datumOpravyFull { get; set; }
        [NotMapped]
        public IList<Najemnik>? najemniks { get; set; }
    }
}
