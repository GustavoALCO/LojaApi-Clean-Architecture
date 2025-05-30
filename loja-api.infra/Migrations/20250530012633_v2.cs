using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loja_api.infra.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cupom_Paymant_CupomId",
                table: "Cupom");

            migrationBuilder.CreateIndex(
                name: "IX_Paymant_CupomId",
                table: "Paymant",
                column: "CupomId",
                unique: true,
                filter: "[CupomId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Paymant_Cupom_CupomId",
                table: "Paymant",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "CupomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paymant_Cupom_CupomId",
                table: "Paymant");

            migrationBuilder.DropIndex(
                name: "IX_Paymant_CupomId",
                table: "Paymant");

            migrationBuilder.AddForeignKey(
                name: "FK_Cupom_Paymant_CupomId",
                table: "Cupom",
                column: "CupomId",
                principalTable: "Paymant",
                principalColumn: "PaymantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
