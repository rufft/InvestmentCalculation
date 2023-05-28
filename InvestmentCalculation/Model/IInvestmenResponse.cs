using InvestmentCalculation.Data.Entities;

namespace InvestmentCalculation.Model;

public interface IInvestmenResponse
{
    float TotalInvest { get; set; }
    public int MeanSalary { get; set; }
    float WorkersCost { get; set; }
    float MachineCost { get; set; }
    float RentCost { get; set; }
    float RegistrationStateTax { get; set; }
    ITaxes Taxes { get; }
    float BusinessAccountingCost { get; set; }
}