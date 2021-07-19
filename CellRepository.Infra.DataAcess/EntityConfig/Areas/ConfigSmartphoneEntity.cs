using CellRepository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.EntityConfig.Areas
{
    public static class ConfigSmartphoneEntity
    {
        public static void Config(ModelBuilder builder)
        {

            var smartphone = builder.Entity<SmartphoneEntity>();

            smartphone.ToTable("Smartphones");

            #region Properties
            smartphone.Property(m => m.SmartphoneName).IsRequired()
                .HasMaxLength(200)
                .HasComment("This columns is to store the name of the smartphone")
                .ValueGeneratedNever();

            smartphone.Property(m => m.Description).IsRequired()
                .HasMaxLength(1500)
                .HasComment("To describe the principal characteristics of the smartphone")
                .ValueGeneratedNever();

            smartphone.Property(m => m.OsName).IsRequired()
                .HasMaxLength(100)
                .HasComment("Describes the version of the smartphone")
                .ValueGeneratedNever();

            smartphone.Property(m => m.LaunchDate).IsRequired()
                .HasColumnType("Date")
                .HasDefaultValue(DateTime.Now)
                .HasComment("Describes the launching date of this smartphone");

            smartphone.Property(m => m.Weight).IsRequired(false)
                .HasColumnType("Numeric(6,2)")
                .HasComment("Describes the weight of the smartphone");

            smartphone.Property(m => m.AntutuPoints).IsRequired(false)
                .HasColumnType("Bigint")
                .HasComment("Display information about the score inside the antutu site");

            smartphone.Property(m => m.CameraPoints).IsRequired()
                .HasColumnType("Numeric(2)")
                .HasComment("Rate 0 to 10 about the camera");

            smartphone.Property(m => m.ScreenPoints).IsRequired()
                .HasColumnType("Numeric(2)")
                .HasComment("Rate 0 to 10 about the screen");

            smartphone.Property(m => m.PerformancePoints).IsRequired()
                .HasColumnType("Numeric(2)")
                .HasComment("Rate 0 to 10 about the performance in overall");
            #endregion
        }
    }
}
