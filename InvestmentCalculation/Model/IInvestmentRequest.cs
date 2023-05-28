using InvestmentCalculation.Data.Entities;

namespace InvestmentCalculation.Model;

public interface IInvestmentRequest
{
    public int CountOfWorkers { get; set; }
    public EconomyBranch EconomyBranch { get; set; }
    public PatentBusinesses PatentBusinesses { get; set; }
    public List<MachineRequestInfo> MachineRequestInfos { get; set; }
    public MoscowDistrict MoscowDistrict { get; set; }
    public int IndustrialArea { get; set; }
    public JurisprudenceCompanyForm JurisprudenceCompanyForm { get; set; }
    public TaxType TaxType { get; set; } 
}