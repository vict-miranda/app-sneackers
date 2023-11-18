using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSneackers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SneackersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Country = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Line1 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Line2 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    PostCode = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sneackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sneackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sneackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sneackers_UserId",
                table: "Sneackers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sneackers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
