using InvestmentCalculation.Data;
using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculation.Controllers;

[Route("api/data")]
public class DataController : ControllerBase
{
    private readonly DataBaseContext _context;

    public DataController(DataBaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("branches")]
    public async Task<ActionResult> GetEconomyBranches()
    {
        var result = await _context.EconomyBranches.ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("machines")]
    public async Task<ActionResult> GetMachines()
    {
        var result = await _context.Machines.ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("districts")]
    public async Task<ActionResult> GetDistricts()
    {
        var result = await _context.MoscowDistricts.ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("patents")]
    public async Task<ActionResult> GetPatents()
    {
        var result = await _context.PatentBusinesses.ToListAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("taxes")]
    public ActionResult GetTaxes()
    {
        var result = new Dictionary<string, int>();
        foreach (var tax in Enum.GetValues<TaxType>())
        {
            result.Add(tax.ToString(), (int) tax);
        }
        return Ok(result);
    }
    
    [HttpGet]
    [Route("jurisprudence-company-types")]
    public ActionResult GetJurisprudenceCompanyTypes()
    {
        var result = new Dictionary<string, int>();
        foreach (var type in Enum.GetValues<JurisprudenceCompanyFormType>())
        {
            result.Add(type.ToString(), (int) type);
        }
        return Ok(result);
    }
}