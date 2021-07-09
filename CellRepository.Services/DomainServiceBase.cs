using CellRepository.Domain.Entities.Utils;
using CellRepository.Infra.DataAcess.UnityOfWork;
using System.Collections.Generic;

namespace CellRepository.DomainServices
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : class
    {
        protected readonly IUnityOfWork UOF;

        //ID - Unique, String as Property and the another String as Message
        protected Dictionary<int, PropertyMessage> MessageError { get; private set; }

        protected void AddMessage(string property, string message)
        {
            PropertyMessage propertyMessage = new(message, property);

            const int NEXT_ELEMENT = 1;

            MessageError.Add(MessageError.Count + NEXT_ELEMENT, propertyMessage);
        }

        public IReadOnlyDictionary<int, PropertyMessage> ReadAllMessages()
        {
            return MessageError;
        }

        public DomainServiceBase(IUnityOfWork unityOfWork)
        {
            UOF = unityOfWork;

            MessageError = new Dictionary<int, PropertyMessage>();
        }
    }
}
