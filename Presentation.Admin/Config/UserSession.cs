using CellRepository.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Admin.Config
{
    public class UserSession
    {
        public string NameInSite { get; private set; }
        public ERoles Role { get; private set; }

        public void UpdateNameLogged(string name)
        {
            NameInSite = name;
        }

        public void UpdateRole(ERoles role)
        {
            Role = role;
        }
    }
}
