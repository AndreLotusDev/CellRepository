using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class removed_smartphone_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfomanceInfo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 18, 38, 29, 950, DateTimeKind.Local).AddTicks(2794),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 12, 18, 26, 17, 630, DateTimeKind.Local).AddTicks(2709),
                oldComment: "Describes the date launching of this smartphone");

            migrationBuilder.AddColumn<long>(
                name: "AntutuPoint",
                table: "Smartphones",
                type: "Bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Display information about the score inside the antutu site");

            migrationBuilder.AddColumn<decimal>(
                name: "CameraPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rate 0 to 10 about the camera");

            migrationBuilder.AddColumn<decimal>(
                name: "PerformancePoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rate 0 to 10 about the performance in overall");

            migrationBuilder.AddColumn<decimal>(
                name: "ScreenPoints",
                table: "Smartphones",
                type: "Numeric(2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rate 0 to 10 about the screen");

            migrationBuilder.AddColumn<int>(
                name: "SmartphoneId",
                table: "Smartphones",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntutuPoint",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "CameraPoints",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "PerformancePoints",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "ScreenPoints",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "SmartphoneId",
                table: "Smartphones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 18, 26, 17, 630, DateTimeKind.Local).AddTicks(2709),
                comment: "Describes the date launching of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 12, 18, 38, 29, 950, DateTimeKind.Local).AddTicks(2794),
                oldComment: "Describes the launching date of this smartphone");

            migrationBuilder.CreateTable(
                name: "PerfomanceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AntutuPoint = table.Column<long>(type: "Bigint", nullable: false, comment: "Display information about the score inside the antutu site"),
                    CameraPoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the camera"),
                    DateOfCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PerformancePoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the performance in overall"),
                    ScreenPoints = table.Column<decimal>(type: "Numeric(2)", nullable: false, comment: "Rate 0 to 10 about the screen"),
                    SmartphoneId = table.Column<int>(type: "integer", nullable: false),
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
    }
}
