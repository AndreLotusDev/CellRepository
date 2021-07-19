using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class antutu_point_column_bug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformanceInfoId",
                table: "Smartphones");

            migrationBuilder.RenameColumn(
                name: "AntutuPoint",
                table: "Smartphones",
                newName: "AntutuPoints");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 11, 56, 43, 355, DateTimeKind.Local).AddTicks(9974),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 17, 3, 58, 25, 326, DateTimeKind.Local).AddTicks(4326),
                oldComment: "Describes the launching date of this smartphone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntutuPoints",
                table: "Smartphones",
                newName: "AntutuPoint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 17, 3, 58, 25, 326, DateTimeKind.Local).AddTicks(4326),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 19, 11, 56, 43, 355, DateTimeKind.Local).AddTicks(9974),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AddColumn<int>(
                name: "PerformanceInfoId",
                table: "Smartphones",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
