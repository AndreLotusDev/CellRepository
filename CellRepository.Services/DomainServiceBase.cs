using CellRepository.Infra.DataAcess.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.DomainServices
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : class
    {
        protected readonly IUnityOfWork UOF;

        public DomainServiceBase(IUnityOfWork unityOfWork)
        {
            UOF = unityOfWork;
        }
    }
}
