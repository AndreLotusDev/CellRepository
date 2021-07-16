using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.User
{
    public interface IUserLoginDomainService : IDomainServiceBase<UserLoginEntity>
    {
        Task<(string message, bool status)> RegisterANewUserAsync(UserLoginEntity userToRegister);
        Task<UserLoginEntity> LoginAsync(UserLoginEntity modelToRecover);
    }
}
