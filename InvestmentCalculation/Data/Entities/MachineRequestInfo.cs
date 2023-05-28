using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Data.Entities;

namespace InvestmentCalculation.Model;

public class MachineRequestInfo : IIdentifier
{
    public MachineRequestInfo(Machine machine, int machineCount)
    {
        Machine = machine;
        MachineCount = machineCount;
    }

    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("machine")]
    public Machine Machine { get; set; }
    
    [Column("machine_count")]
    public int MachineCount { get; set; }
    
    [Column("calculation")]
    public Calculation Calculation { get; set; }
    
    private MachineRequestInfo() {}
}