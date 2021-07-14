using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class added_the_user_table_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 21, 23, 40, 583, DateTimeKind.Local).AddTicks(6698),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 13, 21, 22, 15, 266, DateTimeKind.Local).AddTicks(3609),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.CreateTable(
                name: "UserLoginEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameInSite = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, comment: "This store the name of the user, cannot be equal of another"),
                    RealName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true, comment: "If the user prefer to be called formal, can be the same as the another persons"),
                    Password = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, comment: "The password needs to be encrypted"),
                    Email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, comment: "This column store the email of the user (encrypted)"),
                    LastTimeLogged = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Last time the user logged in the system (WIP)"),
                    TentativesOfLogin = table.Column<short>(type: "smallint", nullable: false, comment: "Stores the number of tentatives of the user trying to enter in the account without success"),
                    MagicCode = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false, comment: "Auto generated code to recover the account"),
                    DateOfCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserIdLastChange = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 21, 22, 15, 266, DateTimeKind.Local).AddTicks(3609),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 13, 21, 23, 40, 583, DateTimeKind.Local).AddTicks(6698),
                oldComment: "Describes the launching date of this smartphone");
        }
    }
}
