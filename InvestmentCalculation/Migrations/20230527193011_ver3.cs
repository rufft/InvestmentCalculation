using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentCalculation.Migrations
{
    /// <inheritdoc />
    public partial class ver3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineRequestInfos_InvestmentCalculations_InvestmentCalcul~",
                table: "MachineRequestInfos");

            migrationBuilder.DropTable(
                name: "InvestmentCalculations");

            migrationBuilder.RenameColumn(
                name: "InvestmentCalculateId",
                table: "MachineRequestInfos",
                newName: "CalculationId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineRequestInfos_InvestmentCalculateId",
                table: "MachineRequestInfos",
                newName: "IX_MachineRequestInfos_CalculationId");

            migrationBuilder.AlterColumn<float>(
                name: "mean_price_per_square_meter",
                table: "MoscowDistricts",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<float>(
                name: "mean_land_rent_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_land_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_moscow_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_personal_income_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_profit_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_property_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "mean_transport_tax",
                table: "EconomyBranches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    ProjectUserId = table.Column<string>(type: "text", nullable: true),
                    company_name = table.Column<int>(type: "integer", nullable: false),
                    mean_salary = table.Column<int>(type: "integer", nullable: false),
                    MoscowDistrictId = table.Column<string>(type: "text", nullable: true),
                    industrial_area = table.Column<int>(type: "integer", nullable: false),
                    jurisprudence_company_form = table.Column<int>(type: "integer", nullable: false),
                    tax_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Calculations_AspNetUsers_ProjectUserId",
                        column: x => x.ProjectUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calculations_MoscowDistricts_MoscowDistrictId",
                        column: x => x.MoscowDistrictId,
                        principalTable: "MoscowDistricts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_MoscowDistrictId",
                table: "Calculations",
                column: "MoscowDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_ProjectUserId",
                table: "Calculations",
                column: "ProjectUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineRequestInfos_Calculations_CalculationId",
                table: "MachineRequestInfos",
                column: "CalculationId",
                principalTable: "Calculations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineRequestInfos_Calculations_CalculationId",
                table: "MachineRequestInfos");

            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropColumn(
                name: "mean_land_rent_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_land_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_moscow_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_personal_income_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_profit_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_property_tax",
                table: "EconomyBranches");

            migrationBuilder.DropColumn(
                name: "mean_transport_tax",
                table: "EconomyBranches");

            migrationBuilder.RenameColumn(
                name: "CalculationId",
                table: "MachineRequestInfos",
                newName: "InvestmentCalculateId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineRequestInfos_CalculationId",
                table: "MachineRequestInfos",
                newName: "IX_MachineRequestInfos_InvestmentCalculateId");

            migrationBuilder.AlterColumn<double>(
                name: "mean_price_per_square_meter",
                table: "MoscowDistricts",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "InvestmentCalculations",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    MoscowDistrictId = table.Column<string>(type: "text", nullable: true),
                    company_name = table.Column<int>(type: "integer", nullable: false),
                    industrial_area = table.Column<int>(type: "integer", nullable: false),
                    jurisprudence_company_form = table.Column<int>(type: "integer", nullable: false),
                    mean_salary = table.Column<int>(type: "integer", nullable: false),
                    tax_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentCalculations", x => x.id);
                    table.ForeignKey(
                        name: "FK_InvestmentCalculations_MoscowDistricts_MoscowDistrictId",
                        column: x => x.MoscowDistrictId,
                        principalTable: "MoscowDistricts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentCalculations_MoscowDistrictId",
                table: "InvestmentCalculations",
                column: "MoscowDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineRequestInfos_InvestmentCalculations_InvestmentCalcul~",
                table: "MachineRequestInfos",
                column: "InvestmentCalculateId",
                principalTable: "InvestmentCalculations",
                principalColumn: "id");
        }
    }
}
