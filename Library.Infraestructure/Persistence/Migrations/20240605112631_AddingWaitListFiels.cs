using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingWaitListFiels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NotifiedAt",
                table: "WaitLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "WaitLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifiedAt",
                table: "WaitLists");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WaitLists");
        }
    }
}
