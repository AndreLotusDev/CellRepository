using CellRepository.Domain.Entities;
using CellRepository.Infra.DataAcess.Interfaces;
using CellRepository.Infra.DataAcess.Interfaces.Repositories.User;

namespace CellRepository.Infra.DataAcess.Areas.User
{
    public class UserLoginRepository : RepositoryBase<UserLoginEntity>, IUserLoginRepository
    {
        public UserLoginRepository(IContext db) : base(db)
        {

        }     
    }
}
