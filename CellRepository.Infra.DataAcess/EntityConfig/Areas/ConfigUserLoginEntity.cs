using CellRepository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.EntityConfig.Areas
{
    public static class ConfigUserLoginEntity
    {
        public static void Config(ModelBuilder builder)
        {

            var user = builder.Entity<UserLoginEntity>();

            user.Property(m => m.Email).IsRequired()
                .HasMaxLength(1000)
                .HasComment("This column store the email of the user (encrypted)");

            user.Property(m => m.NameInSite).IsRequired()
                .HasMaxLength(1000)
                .HasComment("This store the name of the user, cannot be equal of another");

            user.Property(m => m.RealName).IsRequired(false)
                .HasMaxLength(1000)
                .HasComment("If the user prefer to be called formal, can be the same as the another persons");

            user.Property(m => m.TentativesOfLogin).IsRequired()
                .HasColumnType("smallint")
                .HasComment("Stores the number of tentatives of the user trying to enter in the account without success");

            user.Property(m => m.Password).IsRequired()
                .HasMaxLength(1000)
                .HasComment("The password needs to be encrypted");

            user.Property(m => m.MagicCode).IsRequired()
                .HasMaxLength(24)
                .HasComment("Auto generated code to recover the account");

            user.Property(m => m.LastTimeLogged).IsRequired(false)
                .HasComment("Last time the user logged in the system (WIP)");
        }
    }
}
