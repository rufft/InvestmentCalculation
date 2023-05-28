using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;
using InvestmentCalculation.Model.DTO;

namespace InvestmentCalculation.Data.Entities;

public class Calculation : IInvestmentRequest, IInvestmenResponse, IIdentifier
{
    public Calculation(IInvestmentRequest investmentRequest)
    {
        CountOfWorkers = investmentRequest.CountOfWorkers;
        MachineRequestInfos = investmentRequest.MachineRequestInfos;
        MoscowDistrict = investmentRequest.MoscowDistrict;
        IndustrialArea = investmentRequest.IndustrialArea;
        JurisprudenceCompanyForm = investmentRequest.JurisprudenceCompanyForm;
        TaxType = investmentRequest.TaxType;
        PatentBusinesses = investmentRequest.PatentBusinesses;
    }

    public Calculation()
    {
    }

    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }

    [Column("project_user")]
    public ProjectUser ProjectUser { get; set; }
    
    [Column("economy_branch")]
    public EconomyBranch EconomyBranch { get; set; }

    public PatentBusinesses PatentBusinesses { get; set; }

    [Column("company_name")]
    public int CountOfWorkers { get; set; }
    
    [Column("mean_salary")]
    public int MeanSalary { get; set; }
    
    [Column("machine_request_infos")]
    public List<MachineRequestInfo> MachineRequestInfos { get; set; }
    
    [Column("moscow_district")]
    public MoscowDistrict MoscowDistrict { get; set; }
    
    [Column("industrial_area")]
    public int IndustrialArea { get; set; }

    [Column("jurisprudence_company_form")]
    public JurisprudenceCompanyForm JurisprudenceCompanyForm { get; set; }
    
    [Column("total_investment")]
    public float TotalInvestment { get; set; }

    public float TotalInvest { get; set; }

    [Column("workers_cost")]
    public float WorkersCost { get; set; }

    [Column("machine_cost")]
    public float MachineCost { get; set; }
    
    [Column("rent_cost")]
    public float RentCost { get; set; }
    
    [Column("registration_state_tax")]
    public float RegistrationStateTax { get; set; }
    
    [NotMapped]
    public ITaxes Taxes { get; set; }
    
    [Column("business_accounting_cost")]
    public float BusinessAccountingCost { get; set; }
    
    [Column("tax_type")]
    public TaxType TaxType { get; set; }
    

}