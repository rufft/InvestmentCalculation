using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentCalculation.Model;

public class Machine : IIdentifier
{
    public Machine(string machineType, float meanPrice)
    {
        MachineType = machineType;
        MeanPrice = meanPrice;
    }
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("machine_type")]
    public string MachineType { get; set; }
    
    [Column("mean_price")]
    public float MeanPrice { get; set; }
    
    private Machine() {}
}