using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Domain.Entities.Utils
{
    public class PropertyMessage
    {
        public string Message { get; init; }
        public string Property { get; init; }

        public PropertyMessage(string message, string property)
        {
            Message = message;
            Property = property;
        }
    }
}
