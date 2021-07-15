using CellRepository.Domain.Entities.Utils;
using System;
using System.Collections.Generic;

namespace CellRepository.Domain.Entities
{
    public abstract class EntityBase : Valuent
    {
        public int Id { get; private set; }
        public DateTime DateOfCreation { get; private set; }
        public DateTime DateOfUpdate { get; private set; }

        public int UserIdLastChange { get; private set; }

        public void UpdateDateOfCreation()
        {
            DateOfCreation = DateTime.Now;
        }

        public void UpdateDateUpdate()
        {
            DateOfUpdate = DateTime.Now;
        }

        public void ChangeIduser(int idUser)
        {
            UserIdLastChange = idUser;
        }
    }
}