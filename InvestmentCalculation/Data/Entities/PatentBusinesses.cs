using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class PatentBusinesses : IIdentifier
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("name")]
    public string Name { get; set; }

    [Column("mean_possible_profit")] 
    public float MeanPossibleProfit { get; set; }

}