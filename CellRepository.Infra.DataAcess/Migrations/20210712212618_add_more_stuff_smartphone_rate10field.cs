using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class add_more_stuff_smartphone_rate10field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Smartphones");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Smartphones",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpdate",
                table: "Smartphones",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Smartphones",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true,
                comment: "To describe the principal characteristics of the smartphone");

            migrationBuilder.AddColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 18, 26, 17, 630, DateTimeKind.Local).AddTicks(2709),
                comment: "Describes the date launching of this smartphone");

            migrationBuilder.AddColumn<string>(
                name: "OsName",
                table: "Smartphones",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Describes the version of the smartphone");

            migrationBuilder.AddColumn<int>(
                name: "PerformanceInfoId",
                table: "Smartphones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmartphoneName",
                table: "Smartphones",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "This columns is to store the name of the smartphone");

            migrationBuilder.AddColumn<int>(
                name: "UserIdLastChange",
                table: "Smartphones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Smartphones",
                type: "numeric(4,2)",
                nullable: true,
                comment: "Describes the weight of the smartphone");

            migrationBuilder.CreateTable(
                name: "PerfomanceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AntutuPoint = table.Column<long>(type: "Bigint", nullable: false, comment: "Display information about the score inside the antutu site"),
                    CameraPoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the camera"),
                    ScreenPoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the screen"),
                    PerformancePoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the performance in overall"),
                    SmartphoneId = table.Column<int>(type: "integer", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserIdLastChange = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfomanceInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfomanceInfo_Smartphones_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfomanceInfo_SmartphoneId",
                table: "PerfomanceInfo",
                column: "SmartphoneId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfomanceInfo");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "DateOfUpdate",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "LaunchDate",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "OsName",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "PerformanceInfoId",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "SmartphoneName",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "UserIdLastChange",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Smartphones");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Smartphones",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
