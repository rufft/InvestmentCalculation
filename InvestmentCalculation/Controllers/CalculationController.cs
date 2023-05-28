using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Model;
using InvestmentCalculation.Model.DTO;
using InvestmentCalculation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentCalculation.Controllers;

[Route("api/")]
public class CalculationController : ControllerBase
{
    private readonly CalculationService _calculationService;
    private readonly UserManager<ProjectUser> _userManager;

    public CalculationController(
        CalculationService calculationService,
        UserManager<ProjectUser> userManager)
    {
        _calculationService = calculationService;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("calculate")]
    public ActionResult Calculate([FromBody] CalculationRequest investmentRequest)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var user = _userManager.GetUserAsync(User).Result;
        
        var result = _calculationService.Calculate(investmentRequest, user);
        result.ProjectUser = null;
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize]
    [Route("calculations")]
    public async Task<ActionResult> GetCalculations()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null) return BadRequest();

        var result = await _calculationService.GetCalculations(user.Id);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize]
    [Route("calculation/{id}")]
    public async Task<ActionResult> GetCalculation([FromRoute] string calculationId)
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null) return BadRequest();

        var result = _calculationService.GetCalculation(user.Id, calculationId);
        return Ok(result);
    }
    
    [HttpDelete]
    [Authorize]
    [Route("calculation/{id}")]
    public async Task<ActionResult> DeleteCalculation([FromRoute] string calculationId)
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null) return BadRequest();

        var result = _calculationService.DeleteCalculation(user.Id, calculationId);
        return Ok(result);
    }
    
    
}