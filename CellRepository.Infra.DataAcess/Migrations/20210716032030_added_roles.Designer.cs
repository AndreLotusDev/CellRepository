﻿// <auto-generated />
using System;
using CellRepository.Infra.DataAcess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CellRepository.Infra.DataAcess.Migrations
{
    [DbContext(typeof(CellRepositoryContext))]
    [Migration("20210716032030_added_roles")]
    partial class added_roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresEnum(null, "e_roles", new[] { "master", "admin", "basic_user" })
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CellRepository.Domain.Entities.SmartphoneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AntutuPoint")
                        .HasColumnType("Bigint")
                        .HasComment("Display information about the score inside the antutu site");

                    b.Property<decimal?>("CameraPoints")
                        .HasColumnType("Numeric(2)")
                        .HasComment("Rate 0 to 10 about the camera");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)")
                        .HasComment("To describe the principal characteristics of the smartphone");

                    b.Property<DateTime>("LaunchDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValue(new DateTime(2021, 7, 16, 0, 20, 30, 19, DateTimeKind.Local).AddTicks(7944))
                        .HasComment("Describes the launching date of this smartphone");

                    b.Property<string>("OsName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasComment("Describes the version of the smartphone");

                    b.Property<int>("PerformanceInfoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PerformancePoints")
                        .HasColumnType("Numeric(2)")
                        .HasComment("Rate 0 to 10 about the performance in overall");

                    b.Property<decimal?>("ScreenPoints")
                        .HasColumnType("Numeric(2)")
                        .HasComment("Rate 0 to 10 about the screen");

                    b.Property<string>("SmartphoneName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("This columns is to store the name of the smartphone");

                    b.Property<int>("UserIdLastChange")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("numeric(4,2)")
                        .HasComment("Describes the weight of the smartphone");

                    b.HasKey("Id");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("CellRepository.Domain.Entities.UserLoginEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasComment("This column store the email of the user (encrypted)");

                    b.Property<DateTime?>("LastTimeLogged")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("Last time the user logged in the system (WIP)");

                    b.Property<string>("MagicCode")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasComment("Auto generated code to recover the account");

                    b.Property<string>("NameInSite")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasComment("This store the name of the user, cannot be equal of another");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasComment("The password needs to be encrypted");

                    b.Property<string>("RealName")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasComment("If the user prefer to be called formal, can be the same as the another persons");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasComment("Delimits what the user can do and cannt do");

                    b.Property<short>("TentativesOfLogin")
                        .HasColumnType("smallint")
                        .HasComment("Stores the number of tentatives of the user trying to enter in the account without success");

                    b.Property<int>("UserIdLastChange")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserLoginEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
