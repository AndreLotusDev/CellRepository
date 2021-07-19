using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class adding_smartphones_in_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2021, 7, 17, 3, 58, 25, 326, DateTimeKind.Local).AddTicks(4326),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 16, 0, 20, 30, 19, DateTimeKind.Local).AddTicks(7944),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Smartphones",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                comment: "To describe the principal characteristics of the smartphone",
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500,
                oldNullable: true,
                oldComment: "To describe the principal characteristics of the smartphone");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2021, 7, 16, 0, 20, 30, 19, DateTimeKind.Local).AddTicks(7944),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 17, 3, 58, 25, 326, DateTimeKind.Local).AddTicks(4326),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Smartphones",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true,
                comment: "To describe the principal characteristics of the smartphone",
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500,
                oldComment: "To describe the principal characteristics of the smartphone");

            migrationBuilder.AlterColumn<decimal>(
                name: "CameraPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: true,
                comment: "Rate 0 to 10 about the camera",
                oldClrType: typeof(decimal),
                oldType: "Numeric(2)",
                oldComment: "Rate 0 to 10 about the camera");
        }
    }
}
