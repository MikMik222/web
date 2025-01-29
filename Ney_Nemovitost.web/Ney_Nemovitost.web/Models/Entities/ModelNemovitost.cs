
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Ney_Nemovitost.web.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ney_Nemovitost.web.Models.Entities
{
    [Table("Nemovitos")]
    public class ModelNemovitost
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(vlastnik2))]
        public int idVlastnik { get; set; }
        public  User ?vlastnik2 { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double cenaEnergii { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double cenaSluzeb { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double cenaNajmu { get; set; }

        [ForeignKey(nameof(dispoziceNemovitosti))]
        public int idDizpozice { get; set; }

        public DispoziceNemovitosti ? dispoziceNemovitosti { get; set;}

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly dostupnostOd { get; set; }

        [ForeignKey(nameof(enerNarocnost))]
        public int idEneNarocnosti { get; set; }

        public EnerNarocnostNemovitosti ? enerNarocnost { get; set; }

        public double plocha { get; set; }

        [ForeignKey(nameof(adresa))]
        public int idAdresa { get;set; }
        public ModelAdresa? adresa { get; set; }

        [ForeignKey(nameof(optionNemovitost))]
        public int idTypBudovy { get; set; }

        public OptionNemovitost ?optionNemovitost { get; set; }
        public bool vybavenost { get; set; }

        [NotMapped]
        public IList<FotoNem> ?fotografie { get; set; }
    }
}
