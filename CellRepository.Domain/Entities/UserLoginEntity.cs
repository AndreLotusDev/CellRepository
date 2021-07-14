using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Domain.Entities
{
    public class UserLoginEntity : EntityBase
    {
        public UserLoginEntity(DateTime dateOfCreation, DateTime dateOfUpdate, int userIdLastChange) : base(dateOfCreation, dateOfUpdate, userIdLastChange)
        {

        }

        public string NameInSite { get; init; }
        public string RealName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public DateTime? LastTimeLogged { get; init; }
        public int TentativesOfLogin { get; init; }
        public string MagicCode { get; init; }
    }
}
