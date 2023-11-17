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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Address_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_HomePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_HomePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_MobilePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_MobilePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_WorkPhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_WorkPhone_Number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    ContactPhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
