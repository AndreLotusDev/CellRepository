using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class added_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:e_roles", "master,admin,basic_user");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserLoginEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Delimits what the user can do and cannt do");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 0, 20, 30, 19, DateTimeKind.Local).AddTicks(7944),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 15, 2, 30, 37, 771, DateTimeKind.Local).AddTicks(6251),
                oldComment: "Describes the launching date of this smartphone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserLoginEntity");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:e_roles", "master,admin,basic_user");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 15, 2, 30, 37, 771, DateTimeKind.Local).AddTicks(6251),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 16, 0, 20, 30, 19, DateTimeKind.Local).AddTicks(7944),
                oldComment: "Describes the launching date of this smartphone");
        }
    }
}
