using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentCalculation.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EconomyBranches_UserBranchOfTheEconomyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserBranchOfTheEconomyId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserBranchOfTheEconomyId",
                table: "AspNetUsers",
                newName: "branch_of_the_economy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "branch_of_the_economy",
                table: "AspNetUsers",
                newName: "UserBranchOfTheEconomyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserBranchOfTheEconomyId",
                table: "AspNetUsers",
                column: "UserBranchOfTheEconomyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EconomyBranches_UserBranchOfTheEconomyId",
                table: "AspNetUsers",
                column: "UserBranchOfTheEconomyId",
                principalTable: "EconomyBranches",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
