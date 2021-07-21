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
            const int ZERO_LENGHT = 0;

            if(SmartphoneName is null || SmartphoneName.Length == ZERO_LENGHT)
            {
                AddNotification(nameof(SmartphoneName), "Cannt be empty the name of the smartphone");
            }

            if(Description is null || Description.Length == ZERO_LENGHT)
            {
                AddNotification(nameof(Description), "Cannt be empty the descrption of the smartphone");
            }

            if(OsName is null || OsName.Length == ZERO_LENGHT)
            {
                AddNotification(nameof(OsName), "Cannt be empty the OS of the smartphone");
            }

            if(Weight is null || Weight == ZERO_LENGHT)
            {
                AddNotification(nameof(Weight), "Weight cannt be 0");
            }

            return IsOkay();
        }
    }
}
