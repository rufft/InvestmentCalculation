using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class PatentBusinesses : IIdentifier
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("mean_possible_profit")]
    public float MeanPossibleProfit { get; set; }
    
    [Column("mean_moscow_tax")]
    public float MeanMoscowTax { get; set; }
    
    [Column("mean_another_taxes")]
    public float MeanAnotherTaxes { get; set; }
}