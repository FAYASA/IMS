using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.utility
{
    public interface IDbInitializer
    {
        Task CreateSuperAdmin();
        Task SendEmail(string FromEmail, string FromName,
            string Message, string toEmail, string toName, string smtpUser, string smtpPassword,
            string smtpHost, string smtpPort, bool smtpSSl);

        Task<string> UploadFile(List<IFormFile> files,
            IWebHostEnvironment env, string Directory);
    }
}
