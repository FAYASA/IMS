using inventory.models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.utility
{
    public class DbInitializer
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
    }
}
