using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CellRepository.Infra.DataAcess.Migrations
{
    public partial class correction_of_column_weight_smartphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Smartphones",
                type: "numeric(6,2)",
                nullable: true,
                comment: "Describes the weight of the smartphone",
                oldClrType: typeof(decimal),
                oldType: "numeric(4,2)",
                oldNullable: true,
                oldComment: "Describes the weight of the smartphone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 14, 1, 3, 905, DateTimeKind.Local).AddTicks(9545),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 19, 11, 56, 43, 355, DateTimeKind.Local).AddTicks(9974),
                oldComment: "Describes the launching date of this smartphone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Smartphones",
                type: "numeric(4,2)",
                nullable: true,
                comment: "Describes the weight of the smartphone",
                oldClrType: typeof(decimal),
                oldType: "numeric(6,2)",
                oldNullable: true,
                oldComment: "Describes the weight of the smartphone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LaunchDate",
                table: "Smartphones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 11, 56, 43, 355, DateTimeKind.Local).AddTicks(9974),
                comment: "Describes the launching date of this smartphone",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 7, 19, 14, 1, 3, 905, DateTimeKind.Local).AddTicks(9545),
                oldComment: "Describes the launching date of this smartphone");
        }
    }
}
