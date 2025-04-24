using inventory.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.utility
{
    public class DbInitializer :  IDbInitializer
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public void CreateSuperAdmin()
        {
            throw new NotImplementedException();
        }

        public Task SendEmail(string FromEmail, string FromName, string Message, string toEmail, string toName, string smtpUser, string smtpPassword, string smtpHost, string smtpPort, bool smtpSSl)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string Directory)
        {
            throw new NotImplementedException();
        }
    }
}
