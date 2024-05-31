using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingWaitList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoanDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WaitLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitLists_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaitLists_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitLists_IdBook",
                table: "WaitLists",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_WaitLists_IdUser",
                table: "WaitLists",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitLists");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LastLoanDate",
                table: "Books");
        }
    }
}
