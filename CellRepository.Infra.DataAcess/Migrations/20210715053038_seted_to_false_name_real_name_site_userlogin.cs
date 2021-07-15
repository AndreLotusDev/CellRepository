using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class seted_to_false_name_real_name_site_userlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameInSite",
                table: "UserLoginEntity",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                comment: "This store the name of the user, cannot be equal of another",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldComment: "This store the name of the user, cannot be equal of another");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 15, 2, 30, 37, 771, DateTimeKind.Local).AddTicks(6251),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 13, 21, 23, 40, 583, DateTimeKind.Local).AddTicks(6698),
                oldComment: "Describes the launching date of this smartphone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameInSite",
                table: "UserLoginEntity",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                comment: "This store the name of the user, cannot be equal of another",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true,
                oldComment: "This store the name of the user, cannot be equal of another");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 21, 23, 40, 583, DateTimeKind.Local).AddTicks(6698),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 15, 2, 30, 37, 771, DateTimeKind.Local).AddTicks(6251),
                oldComment: "Describes the launching date of this smartphone");
        }
    }
}
