using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class EconomyBranch : IIdentifier
{
    public EconomyBranch(string branchName)
    {
        BranchName = branchName;
    }

    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("branch_name")]
    public string BranchName { get; set; }
    
    [Column("mean_workers_count")]
    public float MeanWorkersCount { get; set; }
    
    [Column("mean_salary")]
    public float MeanSalary { get; set; }

    [Column("mean_moscow_tax")]
    public float MeanMoscowTax { get; set; }

    [Column("mean_profit_tax")] 
    public float MeanProfitTax { get; set; }
    
    [Column("mean_property_tax")]
    public float MeanPropertyTax { get; set; }
    
    [Column("mean_land_tax")]
    public float MeanAreaRentTax { get; set; }
    
    [Column("mean_personal_income_tax")]
    public float MeanPersonalIncomeTax { get; set; }
    
    [Column("mean_transport_tax")]
    public float MeanTransportTax { get; set; }
    
    [Column("mean_land_rent_tax")]
    public float MeanAnotherTaxes { get; set; }

    private EconomyBranch()
    { }
    
}