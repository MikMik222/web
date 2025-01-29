using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class RegisterSmlouvaViewModel
    {
        public ModelSmlouva modelSmlouva { get; set; }
        public IList<Najemnik> ?najemnici { get; set; }
        public DateTime dateOd { get; set; }
        public DateTime dateDo { get; set; }

        public int denVMesiciKdyZaplatit { get; set; } = 1;
        public int vratnaKauce { get; set; } = 1;
        public string cisloUctu { get; set; }
        public int cenaSlevy { get; set; } = 1;
        public int maxPocetOsob { get; set; }
    }
}
