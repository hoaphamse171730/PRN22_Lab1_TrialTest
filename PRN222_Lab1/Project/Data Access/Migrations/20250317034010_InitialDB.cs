using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    YearEstablished = table.Column<int>(type: "int", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CountryofOrigin = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manufact__357E5CA18456C459", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "StoreAccount",
                columns: table => new
                {
                    StoreAccountID = table.Column<int>(type: "int", nullable: false),
                    StoreAccountPassword = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    StoreAccountDescription = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StoreAcc__42D52A6AF7A4E315", x => x.StoreAccountID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineInformation",
                columns: table => new
                {
                    MedicineID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    ActiveIngredients = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    WarningsAndPrecautions = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ManufacturerID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicine__4F2128F0E8E0CD66", x => x.MedicineID);
                    table.ForeignKey(
                        name: "FK__MedicineI__Manuf__3C69FB99",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInformation_ManufacturerID",
                table: "MedicineInformation",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "UQ__StoreAcc__49A1474007BB5BE7",
                table: "StoreAccount",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineInformation");

            migrationBuilder.DropTable(
                name: "StoreAccount");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
