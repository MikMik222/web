using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class RegisterNajmceViewModel : ModelAdresa
    {
        public Najemnik najemnik { get; set; }
        public IList<Predvolby> predvolbys { get; set; }
        public DateTime date { get; set; }
    }
}
