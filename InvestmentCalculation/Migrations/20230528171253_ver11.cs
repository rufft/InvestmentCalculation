using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentCalculation.Migrations
{
    /// <inheritdoc />
    public partial class ver11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "branch_of_the_economy",
                table: "AspNetUsers",
                newName: "UserEconomyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserEconomyBranchId",
                table: "AspNetUsers",
                column: "UserEconomyBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EconomyBranches_UserEconomyBranchId",
                table: "AspNetUsers",
                column: "UserEconomyBranchId",
                principalTable: "EconomyBranches",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EconomyBranches_UserEconomyBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserEconomyBranchId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserEconomyBranchId",
                table: "AspNetUsers",
                newName: "branch_of_the_economy");
        }
    }
}
