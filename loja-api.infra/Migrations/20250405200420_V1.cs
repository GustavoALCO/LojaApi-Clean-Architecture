using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loja_api.infra.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    CupomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auditable_CreatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auditable_UpdatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.CupomId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Auditable_CreatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auditable_UpdatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProducts = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityStorage = table.Column<int>(type: "int", nullable: false),
                    Auditable_CreatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auditable_UpdatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProducts);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    IdStorage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducts = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceBuy = table.Column<double>(type: "float", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Auditable_CreatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auditable_UpdatebyId = table.Column<int>(type: "int", nullable: false),
                    Auditable_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.IdStorage);
                    table.ForeignKey(
                        name: "FK_Storage_Products_IdProducts",
                        column: x => x.IdProducts,
                        principalTable: "Products",
                        principalColumn: "IdProducts",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paymant",
                columns: table => new
                {
                    PaymantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CupomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AttDate_Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttDate_Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paymant", x => x.PaymantId);
                    table.ForeignKey(
                        name: "FK_Paymant_Cupom_CupomId",
                        column: x => x.CupomId,
                        principalTable: "Cupom",
                        principalColumn: "CupomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paymant_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsPaymant",
                columns: table => new
                {
                    MarketCartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdProducts = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsPaymant", x => new { x.MarketCartId, x.IdProducts });
                    table.ForeignKey(
                        name: "FK_ProductsPaymant_Paymant_MarketCartId",
                        column: x => x.MarketCartId,
                        principalTable: "Paymant",
                        principalColumn: "PaymantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsPaymant_Products_IdProducts",
                        column: x => x.IdProducts,
                        principalTable: "Products",
                        principalColumn: "IdProducts",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paymant_CupomId",
                table: "Paymant",
                column: "CupomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paymant_IdUser",
                table: "Paymant",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPaymant_IdProducts",
                table: "ProductsPaymant",
                column: "IdProducts");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_IdProducts",
                table: "Storage",
                column: "IdProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProductsPaymant");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Paymant");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
