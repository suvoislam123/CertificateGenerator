using Microsoft.Extensions.Options;
using PearkyRabbitTest.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerakyRabbitTest.Services
{
    public class MailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }
        public static bool SendOTP()
        {
            return false;
        }
    }
}
