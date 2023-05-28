using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentCalculation.Migrations
{
    /// <inheritdoc />
    public partial class ver4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jurisprudence_company_form",
                table: "Calculations");

            migrationBuilder.AddColumn<float>(
                name: "mean_salary",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_workers_count",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "EconomyBranchId",
                table: "Calculations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JurisprudenceCompanyFormId",
                table: "Calculations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalInvest",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "business_accounting_cost",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "machine_cost",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "registration_state_tax",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "rent_cost",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "total_investment",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "workers_cost",
                table: "Calculations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "JurisprudenceCompanyForm",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    jurisprudence_company_form_type = table.Column<int>(type: "integer", nullable: false),
                    registration_state_tax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurisprudenceCompanyForm", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_EconomyBranchId",
                table: "Calculations",
                column: "EconomyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_JurisprudenceCompanyFormId",
                table: "Calculations",
                column: "JurisprudenceCompanyFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_EconomyBranches_EconomyBranchId",
                table: "Calculations",
                column: "EconomyBranchId",
                principalTable: "EconomyBranches",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForm_JurisprudenceCompanyF~",
                table: "Calculations",
                column: "JurisprudenceCompanyFormId",
                principalTable: "JurisprudenceCompanyForm",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_EconomyBranches_EconomyBranchId",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForm_JurisprudenceCompanyF~",
                table: "Calculations");

            migrationBuilder.DropTable(
                name: "JurisprudenceCompanyForm");

            migrationBuilder.DropIndex(
                name: "IX_Calculations_EconomyBranchId",
                table: "Calculations");

            migrationBuilder.DropIndex(
                name: "IX_Calculations_JurisprudenceCompanyFormId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "mean_salary",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_workers_count",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "EconomyBranchId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "JurisprudenceCompanyFormId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "TotalInvest",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "business_accounting_cost",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "machine_cost",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "registration_state_tax",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "rent_cost",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "total_investment",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "workers_cost",
                table: "Calculations");

            migrationBuilder.AddColumn<int>(
                name: "jurisprudence_company_form",
                table: "Calculations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
