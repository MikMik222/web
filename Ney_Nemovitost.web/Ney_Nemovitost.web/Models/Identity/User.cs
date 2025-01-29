using Microsoft.AspNetCore.Identity;
using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public User() : base()
        {

        }

        public User(string userName) : base(userName)
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly datumNarozeni { get; set; }
        public string rodneCislo { get; set; }

        [ForeignKey(nameof(adresa))]
        public int idAdres { get; set; }
        public ModelAdresa adresa { get; set; }

        [ForeignKey(nameof(predvolby))]
        public int idPredvolby { get; set; }
        public Predvolby predvolby { get; set; }
    }
}
