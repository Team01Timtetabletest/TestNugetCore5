using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(string userName) : base(userName) { }
    }
}
