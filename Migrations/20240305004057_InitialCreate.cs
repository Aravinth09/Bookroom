using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookroom.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Roomtypes",
                columns: table => new
                {
                    RoomtypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Roomrent = table.Column<decimal>(type: "TEXT", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roomtypes", x => x.RoomtypeId);
                });

            migrationBuilder.CreateTable(
                name: "Bookingorder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentalStartDate = table.Column<string>(type: "TEXT", nullable: false),
                    RentalEndDate = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingorder", x => new { x.OrderId, x.CustomerId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_Bookingorder_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookingorder_Roomtypes_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Roomtypes",
                        principalColumn: "RoomtypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    PriceId = table.Column<string>(type: "TEXT", nullable: false),
                    RentalRatePerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    Discounts = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Rents_Roomtypes_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Roomtypes",
                        principalColumn: "RoomtypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookingorder_CustomerId",
                table: "Bookingorder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingorder_RoomId",
                table: "Bookingorder",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RoomId",
                table: "Rents",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookingorder");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roomtypes");
        }
    }
}
