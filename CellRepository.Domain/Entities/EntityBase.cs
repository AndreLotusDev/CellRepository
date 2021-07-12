using CellRepository.Domain.Entities.Utils;
using System;
using System.Collections.Generic;

namespace CellRepository.Domain.Entities
{
    public abstract class EntityBase : Valuent
    {
        protected EntityBase(DateTime dateOfCreation, DateTime dateOfUpdate, int userIdLastChange)
        {
            DateOfCreation = dateOfCreation;
            DateOfUpdate = dateOfUpdate;
            UserIdLastChange = userIdLastChange;
        }

        public int Id { get; private set; }
        public DateTime DateOfCreation { get; init; }
        public DateTime DateOfUpdate { get; init; }

        public int UserIdLastChange { get; init; }

    }
}