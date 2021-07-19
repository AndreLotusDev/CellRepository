using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.User
{
    public interface IUserLoginDomainService : IDomainServiceBase<UserLoginEntity>
    {
        Task<(string message, bool status)> RegisterANewUserAsync(UserLoginEntity userToRegister);
        Task<(UserLoginEntity user, string message, bool status)> LoginAsync(UserLoginEntity modelToRecover);
    }
}
