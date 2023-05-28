using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class JurisprudenceCompanyForm : IIdentifier
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    [Column("jurisprudence_company_form_type")]
    public JurisprudenceCompanyFormType JurisprudenceCompanyFormType { get; set; }
    
    [Column("registration_state_tax")]
    public float RegistrationStateTax { get; set; }
}