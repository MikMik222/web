using Microsoft.AspNetCore.Identity;

namespace Ney_Nemovitost.web.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role() : base()
        {

        }

        public Role(string roleName) : base(roleName)
        {

        }
    }
}
