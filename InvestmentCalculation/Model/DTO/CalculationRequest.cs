using System.ComponentModel.DataAnnotations;
using InvestmentCalculation.Data.Entities;

namespace InvestmentCalculation.Model.DTO;

public class CalculationRequest
{
    //[Required]
    public int CountOfWorkers { get; set; }
    
    public string EconomyBranchId { get; set; }
    
    public string PatentBusinessesId { get; set; }

    //[Required]
    public Dictionary<string, int> MachineRequestInfosDict { get; set; }
    
    //[Required]
    public string MoscowDistrictId { get; set; }
    
    //[Required]
    public int IndustrialArea { get; set; }
   
    //[Required]
    public JurisprudenceCompanyFormType JurisprudenceCompanyFormType { get; set; }
    
    //[Required]
    public TaxType TaxType { get; set; }
}