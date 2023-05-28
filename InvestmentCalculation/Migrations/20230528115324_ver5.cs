using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentCalculation.Migrations
{
    /// <inheritdoc />
    public partial class ver5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForm_JurisprudenceCompanyF~",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineRequestInfos_Machine_MachineId",
                table: "MachineRequestInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machine",
                table: "Machine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JurisprudenceCompanyForm",
                table: "JurisprudenceCompanyForm");

            migrationBuilder.RenameTable(
                name: "Machine",
                newName: "Machines");

            migrationBuilder.RenameTable(
                name: "JurisprudenceCompanyForm",
                newName: "JurisprudenceCompanyForms");

            migrationBuilder.AddColumn<string>(
                name: "PatentBusinessesId",
                table: "Calculations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "mean_price",
                table: "Machines",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JurisprudenceCompanyForms",
                table: "JurisprudenceCompanyForms",
                column: "id");

            migrationBuilder.CreateTable(
                name: "BusinessAccountings",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    business_accounting_type = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAccountings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PatentBusinesses",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    mean_possible_profit = table.Column<float>(type: "real", nullable: false),
                    mean_moscow_tax = table.Column<float>(type: "real", nullable: false),
                    mean_another_taxes = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatentBusinesses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_PatentBusinessesId",
                table: "Calculations",
                column: "PatentBusinessesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForms_JurisprudenceCompany~",
                table: "Calculations",
                column: "JurisprudenceCompanyFormId",
                principalTable: "JurisprudenceCompanyForms",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_PatentBusinesses_PatentBusinessesId",
                table: "Calculations",
                column: "PatentBusinessesId",
                principalTable: "PatentBusinesses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineRequestInfos_Machines_MachineId",
                table: "MachineRequestInfos",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForms_JurisprudenceCompany~",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_PatentBusinesses_PatentBusinessesId",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineRequestInfos_Machines_MachineId",
                table: "MachineRequestInfos");

            migrationBuilder.DropTable(
                name: "BusinessAccountings");

            migrationBuilder.DropTable(
                name: "PatentBusinesses");

            migrationBuilder.DropIndex(
                name: "IX_Calculations_PatentBusinessesId",
                table: "Calculations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JurisprudenceCompanyForms",
                table: "JurisprudenceCompanyForms");

            migrationBuilder.DropColumn(
                name: "PatentBusinessesId",
                table: "Calculations");

            migrationBuilder.RenameTable(
                name: "Machines",
                newName: "Machine");

            migrationBuilder.RenameTable(
                name: "JurisprudenceCompanyForms",
                newName: "JurisprudenceCompanyForm");

            migrationBuilder.AlterColumn<double>(
                name: "mean_price",
                table: "Machine",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machine",
                table: "Machine",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JurisprudenceCompanyForm",
                table: "JurisprudenceCompanyForm",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_JurisprudenceCompanyForm_JurisprudenceCompanyF~",
                table: "Calculations",
                column: "JurisprudenceCompanyFormId",
                principalTable: "JurisprudenceCompanyForm",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineRequestInfos_Machine_MachineId",
                table: "MachineRequestInfos",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "id");
        }
    }
}
