using CellRepository.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Domain.Entities
{
    public class UserLoginEntity : EntityBase
    {
        public string NameInSite { get; init; }
        public string RealName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public DateTime? LastTimeLogged { get; private set; }
        public int TentativesOfLogin { get; private set; }
        public string MagicCode { get; private set; }
        public ERoles Role { get; private set; }

        public void SetTentativeOfLoginRegister()
        {
            TentativesOfLogin = 0;
        }

        public void SetMagicCode()
        {
            MagicCode = Guid.NewGuid().ToString().Remove(23);
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
