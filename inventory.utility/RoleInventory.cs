using inventory.models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.utility
{
    public class RoleInventory : IRoleInventory
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public RoleInventory(RoleManager<IdentityRole> roleManager, 
            UserManager<AppUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task AddRoleAsync(string AppUserId)
        {
            var user= await _userManager.FindByNameAsync(AppUserId);
            var roles = _roleManager.Roles;
            List<string> StringRoles = new List<string>();

            if (user != null) {
                foreach (var role in roles)
                {
                    StringRoles.Add(role.Name);
                }
                await _userManager.AddToRolesAsync(user, StringRoles);
            
            }
        }

        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenu);
            foreach (Type classObj in t.GetNestedTypes())
            {
                foreach (var objField in classObj.GetFields())
                {
                    if(objField.Name.Contains("RoleName"))
                    {
                        if (!await _roleManager.RoleExistsAsync(objField.Name))
                            await _roleManager.CreateAsync(new IdentityRole(objField.Name));
                    }
                }
            }
        }
    }
}
