using InvestmentCalculation.Data;
using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Model;
using InvestmentCalculation.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculation.Services;

public class CalculationService
{

    private const int WorkersMaxCount = 15;
    private const int IndustrialMaxArea = 150;
        
    
    private readonly DataBaseContext _context;

    public CalculationService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<Calculation>?> GetCalculations(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;

        return await user.Calculations.ToListAsync();
    }
    
    public async Task<List<Calculation>?> GetCalculations()
    {
        return await _context.Calculations.ToListAsync();
    }
    
    public async Task<Calculation?> GetCalculation(string userId, string calculationId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;

        return await user.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
    }
    
    public async Task<Calculation?> GetCalculation(string calculationId)
    {
        return await _context.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
    }
    
    public async Task<bool> DeleteCalculation(string userId, string calculationId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return false;

        var calculation = await user.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
        if (calculation == null) return false;

        _context.Calculations.Remove(calculation);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteCalculation(string calculationId)
    {
        var calculation = await _context.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
        if (calculation == null) return false;

        _context.Calculations.Remove(calculation);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAllCalculations(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return false;

        _context.Calculations.RemoveRange(user.Calculations);
        await _context.SaveChangesAsync();
        return true;
    }

    public IInvestmenResponse Calculate(CalculationRequest investmentRequest)
    {
        
        IInvestmenResponse investmentResponse;
        
        var request = _dtoToCalculateRequest(investmentRequest);

        investmentResponse = CalculateStartInvestFormula(request);

        return investmentResponse;
    }
    
    private IInvestmentRequest _dtoToCalculateRequest (CalculationRequest investmentRequest)
    {
        var calculation = new Calculation();
        
        calculation.CountOfWorkers = investmentRequest.CountOfWorkers;
        calculation.IndustrialArea = investmentRequest.IndustrialArea;
        calculation.MoscowDistrict = _context.MoscowDistricts.FirstOrDefault(d => d.Id == investmentRequest.MoscowDistrictId) ?? throw new InvalidOperationException();
        calculation.EconomyBranch = _context.EconomyBranches.FirstOrDefault(b => b.Id == investmentRequest.EconomyBranchId) ?? throw new InvalidOperationException();
        calculation.MachineRequestInfos = new List<MachineRequestInfo>();
        foreach (var machineRequestInfo in investmentRequest.MachineRequestInfosDict)
        {
            var machine = _context.Machines.FirstOrDefault(m => m.Id == machineRequestInfo.Key) ?? throw new InvalidOperationException();
            calculation.MachineRequestInfos.Add(new MachineRequestInfo(machine, machineRequestInfo.Value));
        }
        calculation.JurisprudenceCompanyForm = _context.JurisprudenceCompanyForms.FirstOrDefault(f => f.JurisprudenceCompanyFormType == investmentRequest.JurisprudenceCompanyFormType) ?? throw new InvalidOperationException();
        calculation.PatentBusinesses = _context.PatentBusinesses.FirstOrDefault(p => p.Id == investmentRequest.PatentBusinessesId) ?? throw new InvalidOperationException();
        calculation.TaxType = investmentRequest.TaxType;

        return calculation;
    }

    private IInvestmenResponse CalculateStartInvestFormula(IInvestmentRequest investmentCalculateRequest)
    {
        var calculation = new Calculation(investmentCalculateRequest);

        float workersCost = investmentCalculateRequest.CountOfWorkers * investmentCalculateRequest.EconomyBranch.MeanSalary;
        calculation.TotalInvest += workersCost;
        calculation.WorkersCost = workersCost;

        for (int i = 0; i < investmentCalculateRequest.MachineRequestInfos.Count; i++)
        {
            float machinesCost = 0.0f;
            var machineRequestInfo = investmentCalculateRequest.MachineRequestInfos[i];
            machinesCost += machineRequestInfo.Machine.MeanPrice * machineRequestInfo.MachineCount;
            calculation.TotalInvest += machinesCost;
            calculation.MachineCost += machinesCost;
        }

        float industrialAreaCoast = investmentCalculateRequest.IndustrialArea * investmentCalculateRequest.MoscowDistrict.MeanPricePerSquareMeter;
        calculation.TotalInvest += industrialAreaCoast;
        calculation.RentCost = industrialAreaCoast;

        float registrationStateTax = investmentCalculateRequest.JurisprudenceCompanyForm.RegistrationStateTax;
        calculation.TotalInvest += registrationStateTax;
        calculation.RegistrationStateTax = registrationStateTax;

        float taxes;
        if (investmentCalculateRequest.CountOfWorkers <= WorkersMaxCount
            && investmentCalculateRequest.JurisprudenceCompanyForm.JurisprudenceCompanyFormType == JurisprudenceCompanyFormType.SP
            && investmentCalculateRequest.IndustrialArea <= IndustrialMaxArea)
        {
            taxes = CalculatePatenTaxes(investmentCalculateRequest);
        }
        else
        {
            taxes = CalculateTaxes(investmentCalculateRequest);
        }
        float businessAccountingCost = CalculateBusinessAccountingCost(investmentCalculateRequest);

        calculation.TotalInvest += taxes;
        calculation.TotalInvest += businessAccountingCost;
        calculation.BusinessAccountingCost = businessAccountingCost;

        _context.Calculations.Add(calculation);
        return calculation;
    }
    
    private float CalculatePatenTaxes(IInvestmentRequest investmentCalculateRequest)
    {
        float taxes;
        var patentBusinesses = investmentCalculateRequest.PatentBusinesses;
        taxes = patentBusinesses.MeanPossibleProfit + patentBusinesses.MeanMoscowTax + patentBusinesses.MeanAnotherTaxes;
        return taxes;
    }
    
    private float CalculateTaxes(IInvestmentRequest investmentCalculateRequest)
    {
        float taxes;
        var economyBranch = investmentCalculateRequest.EconomyBranch;

        switch (investmentCalculateRequest.TaxType)
        {
            case TaxType.GTS:
                taxes = GTS_taxes(economyBranch);
                break;
            case TaxType.STS:
                taxes = SP_STS_taxes(economyBranch);
                break;
            default:
                taxes = 0f;
                break;
        }
        return taxes;
    }
    private float CalculateBusinessAccountingCost(IInvestmentRequest investmentCalculateRequest)
    {
        float businessAccountingCost;

        switch (investmentCalculateRequest.TaxType)
        {
            case TaxType.GTS:
                if (investmentCalculateRequest.JurisprudenceCompanyForm.JurisprudenceCompanyFormType == JurisprudenceCompanyFormType.SP)
                {
                    businessAccountingCost = _context.BusinessAccountings.FirstOrDefault(b => b.BusinessAccountingType == BusinessAccountingType.GTS_SP)!.Cost;
                }
                else
                {
                    businessAccountingCost = _context.BusinessAccountings.FirstOrDefault(b => b.BusinessAccountingType == BusinessAccountingType.GTS_Company)!.Cost;
                }
                break;
            case TaxType.STS:
                if (investmentCalculateRequest.JurisprudenceCompanyForm.JurisprudenceCompanyFormType == JurisprudenceCompanyFormType.SP)
                {
                    businessAccountingCost = _context.BusinessAccountings.FirstOrDefault(b => b.BusinessAccountingType == BusinessAccountingType.STS_SP)!.Cost;
                }
                else
                {
                    businessAccountingCost = _context.BusinessAccountings.FirstOrDefault(b => b.BusinessAccountingType == BusinessAccountingType.STS_Company)!.Cost;
                }
                break;
            default:
                businessAccountingCost = 0f;
                break;
    }
    return businessAccountingCost;
}

private float GTS_taxes(EconomyBranch branch)
{
    return branch.MeanMoscowTax
            + branch.MeanProfitTax
            + branch.MeanPropertyTax
            + branch.MeanAreaRentTax
            + branch.MeanPersonalIncomeTax
            + branch.MeanTransportTax
            + branch.MeanAnotherTaxes;
}

private float SP_STS_taxes(EconomyBranch branch)
{
    return branch.MeanMoscowTax
            + branch.MeanPersonalIncomeTax
            + branch.MeanTransportTax
            + branch.MeanAnotherTaxes;
}
}