using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using CellRepository.Infra.DataAcess.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.User
{
    public class UserLoginDomainService : DomainServiceBase<SmartphoneEntity> , IUserLoginDomainService
    {
        public UserLoginDomainService(IUnityOfWork uof): base(uof){}

        public async Task<(string message, bool status)> RegisterANewUserAsync(UserLoginEntity userToRegister)
        {
            var userAlreadyExist = await UOF.UserLoginRepository
                                    .GetAsync(m => m.Email == userToRegister.Email || m.NameInSite == userToRegister.NameInSite);

            if(userAlreadyExist is null)
            {
                if (userToRegister.IsOkay())
                {
                    userToRegister.SetMagicCode();
                    userToRegister.SetTentativeOfLoginRegister();
                    userToRegister.UpdateDateOfCreation();
                    userToRegister.UpdateDateUpdate();

                    await UOF.UserLoginRepository.AddAsync(userToRegister);
                    await UOF.CommitAsync();

                    return ("User saved with success", true);
                }
            }

            else if (userAlreadyExist.Email == userToRegister.Email)
            {
                return ("This emails is already being used", false);
            }

            else if (userAlreadyExist.NameInSite == userToRegister.NameInSite)
            {
                return ("This name of user is already being used", false);
            }

            return ("OK?", true);
        }
    }
}
