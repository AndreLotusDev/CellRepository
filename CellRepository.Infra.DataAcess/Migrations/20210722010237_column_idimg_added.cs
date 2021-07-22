using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class column_idimg_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 22, 2, 37, 450, DateTimeKind.Local).AddTicks(5404),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 19, 14, 1, 3, 905, DateTimeKind.Local).AddTicks(9545),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.AddColumn<string>(
                name: "IdImage",
                table: "Smartphones",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "Smartphones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 14, 1, 3, 905, DateTimeKind.Local).AddTicks(9545),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 21, 22, 2, 37, 450, DateTimeKind.Local).AddTicks(5404),
                oldComment: "Describes the launching date of this smartphone");
        }
    }
}
