using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class added_the_user_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmartphoneId",
                table: "Smartphones");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScreenPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: true,
                comment: "Rate 0 to 10 about the screen",
                oldClrType: typeof(decimal),
                oldType: "Numeric(2)",
                oldComment: "Rate 0 to 10 about the screen");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 21, 22, 15, 266, DateTimeKind.Local).AddTicks(3609),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 12, 18, 38, 29, 950, DateTimeKind.Local).AddTicks(2794),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AlterColumn<decimal>(
                name: "CameraPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: true,
                comment: "Rate 0 to 10 about the camera",
                oldClrType: typeof(decimal),
                oldType: "Numeric(2)",
                oldComment: "Rate 0 to 10 about the camera");

            migrationBuilder.AlterColumn<long>(
                name: "AntutuPoint",
                table: "Smartphones",
                type: "Bigint",
                nullable: true,
                comment: "Display information about the score inside the antutu site",
                oldClrType: typeof(long),
                oldType: "Bigint",
                oldComment: "Display information about the score inside the antutu site");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ScreenPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rate 0 to 10 about the screen",
                oldClrType: typeof(decimal),
                oldType: "Numeric(2)",
                oldNullable: true,
                oldComment: "Rate 0 to 10 about the screen");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 18, 38, 29, 950, DateTimeKind.Local).AddTicks(2794),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 13, 21, 22, 15, 266, DateTimeKind.Local).AddTicks(3609),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AlterColumn<decimal>(
                name: "CameraPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rate 0 to 10 about the camera",
                oldClrType: typeof(decimal),
                oldType: "Numeric(2)",
                oldNullable: true,
                oldComment: "Rate 0 to 10 about the camera");

            migrationBuilder.AlterColumn<long>(
                name: "AntutuPoint",
                table: "Smartphones",
                type: "Bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Display information about the score inside the antutu site",
                oldClrType: typeof(long),
                oldType: "Bigint",
                oldNullable: true,
                oldComment: "Display information about the score inside the antutu site");

            migrationBuilder.AddColumn<int>(
                name: "SmartphoneId",
                table: "Smartphones",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
