using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationModels
{
    public class SmartphoneDto
    {
        public int Id { get; set; }
        public string SmartphoneName { get; set; }
        public string Description { get; set; }
        public string OsName { get; set; }
        public DateTime LaunchDate { get; set; }
        public double? Weight { get; set; }

        public int AntutuPoint { get; set; }
        public int CameraPoints { get; set; }
        public int ScreenPoints { get; set; }
        public int PerformancePoints { get; set; }
    }
}
