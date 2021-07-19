using System;

namespace CellRepository.Domain.Entities
{
    public class SmartphoneEntity : EntityBase
    {
        public string SmartphoneName { get; init; }
        public string Description { get; init; }
        public string OsName { get; init; }
        public DateTime LaunchDate { get; init; }
        public double? Weight { get; init; }

        public int? AntutuPoints { get; init; }
        public int CameraPoints { get; init; }
        public int ScreenPoints { get; init; }
        public int PerformancePoints { get; init; }

        public override bool Validate()
        {
            if(SmartphoneName.Length > 0)
            {
                AddNotification(nameof(SmartphoneName), "Cannt be empty the name of the smartphone");
            }

            if(Description.Length > 0)
            {
                AddNotification(nameof(Description), "Cannt be empty the descrption of the smartphone");
            }

            if(OsName.Length > 0)
            {
                AddNotification(nameof(OsName), "Cannt be empty the OS of the smartphone");
            }

            if(Weight <= 0)
            {
                AddNotification(nameof(Weight), "Weight needs to be");
            }

            return IsOkay();
        }
    }
}
