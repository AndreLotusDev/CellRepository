﻿using System;

namespace CellRepository.Domain.Entities
{
    public class SmartphoneEntity : EntityBase
    {
        public string SmartphoneName { get; init; }
        public string Description { get; init; }
        public string OsName { get; init; }
        public DateTime LaunchDate { get; init; }
        public double? Weight { get; init; }

        public int PerformanceInfoId { get; init; }
        public int? AntutuPoint { get; init; }
        public int? CameraPoints { get; init; }
        public int? ScreenPoints { get; init; }
        public int PerformancePoints { get; init; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
