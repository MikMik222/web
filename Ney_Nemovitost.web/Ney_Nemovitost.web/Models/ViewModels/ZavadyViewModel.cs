using Ney_Nemovitost.web.Models.Entities;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class ZavadyViewModel
    {
        public ModelNemovitost modelNemovitost { get; set; }
        public IList <ModelZavady> modelZavadies { get; set; }
    }
}
