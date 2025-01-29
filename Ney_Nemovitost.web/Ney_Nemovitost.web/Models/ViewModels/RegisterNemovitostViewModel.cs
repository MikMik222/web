using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class RegisterNemovitostViewModel: ModelAdresa
    {
        public IList <FotoNem> FotoNems { get; set; }
        [NotMapped]
        public IList <IFormFile> Images { get; set; }
        public IList <DispoziceNemovitosti> Dispozices { get; set; }
        public IList <EnerNarocnostNemovitosti> enerNarocnostNemovitostis { get; set; }
        public IList <OptionNemovitost> typBudovy { get; set; }
        [Required]
        public ModelNemovitost modelNemovitost { get; set;}
        public DateTime date { get; set; }
        public DateTime datumOd { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaVody { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaPlynu { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaElektriky { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaInternetu { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaUklidu { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaOdpadu { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int cenaSpolecneEleketriky { get; set; } = 0;
    }
}
