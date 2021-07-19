using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Admin.Config
{
    public static class ConfigSession
    {
        public static UserSession UserSession { get; set; }

        public static string EncryptKey { get => "D*G-KaPdSgVkYp3s5v8y/B?E(H+MbQeT"; }
    }
}
