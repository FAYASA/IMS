using inventory.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.utility
{
    public class RoleInventory : IRoleInventory
    {
        /// <summary>
        /// using Dependency Injection (DI) to access ASP.NET Identity's role
        /// and user management functionality inside utility class
        /// 
        /// 🔹 RoleManager<IdentityRole> _roleManager
        /// Used to manage roles in the identity system.
        /// Key capabilities include:
        /// Creating roles(CreateAsync)
        /// Deleting roles
        /// Checking if a role exists(RoleExistsAsync)
        /// Accessing all roles(Roles property)
        /// 
        /// 🔹 UserManager<AppUser> _userManager
        /// Used to manage users(based on your custom AppUser class, which likely extends IdentityUser).
        /// Key capabilities include:
        /// Finding users by ID or name(FindByIdAsync, FindByNameAsync)
        /// Creating/deleting users
        /// Managing passwords
        /// Assigning/removing roles(AddToRoleAsync, AddToRolesAsync)
        /// Checking roles(IsInRoleAsync)
        /// 
        /// </summary>
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public RoleInventory(RoleManager<IdentityRole> roleManager, 
            UserManager<AppUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        /////////////////////////////////////////////////////////////////////////
        public async Task AddRoleAsync(string AppUserId)
        {
            var user = await _userManager.FindByNameAsync(AppUserId); // This line tries to find a user by username.
            var roles = _roleManager.Roles; // Retrieves all existing roles in the system.
            List<string> StringRoles = new List<string>();

            if (user != null) {
                foreach (var role in roles)
                {
                    StringRoles.Add(role.Name); // Adds the role’s name to the StringRoles list.
                }
                /// Assigns all roles to that user using AddToRolesAsync.///
                await _userManager.AddToRolesAsync(user, StringRoles); 
            }
        }
        /// <summary>
        /// 
        /// Uses reflection to dynamically scan nested classes in TopMenu.
        /// Looks for fields named like "RoleName".
        /// Extracts their values and creates roles accordingly using RoleManager.
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenu);

            foreach (Type classObj in t.GetNestedTypes())
            {
                foreach (var objField in classObj.GetFields())
                {
                    if(objField.Name.Contains("RoleName"))
                    {
                        var roleName = (string)objField.GetValue(objField);
                        if (!await _roleManager.RoleExistsAsync(roleName))
                            await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
    }
}
