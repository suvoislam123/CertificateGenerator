using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PearkyRabbitTest.Models.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }= string.Empty;
        public ICollection<Certificate> Certificates { get; set; }  
    }
}
