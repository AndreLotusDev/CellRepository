using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Domain.Entities
{
    public class SmartphoneEntity : EntityBase
    {
        public string Name { get; }

        public string StorageCapacity { get; }

        public double PriceInBrazil { get; }

        public double AndroidVersion { get; }

        public double ScreenAvaliation { get; }

        public double PerformanceAvaliation { get;  }
        public double PriceAvaliation { get; }

        public double LowestPrice { get; }


    }
}
