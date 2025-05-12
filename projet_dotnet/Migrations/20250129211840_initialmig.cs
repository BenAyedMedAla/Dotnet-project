using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dotnet.Migrations
{
    public partial class initialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    book_title = table.Column<string>(type: "TEXT", nullable: false),
                    matiere = table.Column<string>(type: "TEXT", nullable: false),
                    author = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.book_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Filiere = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookUser_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UserId",
                table: "BookUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
