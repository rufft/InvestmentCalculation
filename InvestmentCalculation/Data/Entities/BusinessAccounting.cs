using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class BusinessAccounting : IIdentifier
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("business_accounting_type")]
    public BusinessAccountingType BusinessAccountingType { get; set; }
    
    [Column("cost")]
    public float Cost { get; set; }
}