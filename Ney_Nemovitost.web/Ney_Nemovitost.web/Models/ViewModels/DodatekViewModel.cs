using Ney_Nemovitost.web.Models.Entities;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class DodatekViewModel
    {
        public ModelNemovitost modelNemovitost { get; set; }

        public ModelSmlouva modelSmlouva { get; set; }
        public Najemnik najemnik { get; set; }
        public IList <TypyDodatku> typyDodatkus { get; set; }
    }
}
