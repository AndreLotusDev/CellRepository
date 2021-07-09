using CellRepository.Domain.Entities.Utils;
using System.Collections.Generic;

namespace CellRepository.Domain.Entities
{
    public abstract class EntityBase : Valuent
    { 
        public int Id { get; set; }

    }
}