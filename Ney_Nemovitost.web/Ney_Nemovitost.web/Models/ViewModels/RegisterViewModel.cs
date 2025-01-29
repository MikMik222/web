using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class RegisterViewModel : ModelAdresa
    {
        [Required]
        public string Username { get; set; }

        public string rodneCislo { get; set; }
        public DateTime datumNarozeni { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Predvolby> Predvolbys { get; set; }
        public int idPredvolby { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
        public string? RepeatedPassword { get; set; }
    }
}
