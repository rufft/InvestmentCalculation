using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculation.Controllers;

[Route("api/admin")]
[Authorize(Roles = "admin")]
public class AdminController : ControllerBase
{
    
    private readonly SignInManager<ProjectUser> _signInManager;
    private readonly UserManager<ProjectUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly CalculationService _calculationService;
    public AdminController(
        SignInManager<ProjectUser> signInManager,
        UserManager<ProjectUser> userManager,
        RoleManager<IdentityRole> roleManager,
        CalculationService calculationService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _calculationService = calculationService;
    }
    
    /// <summary>
    /// Добавить роль администратора пользователю
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("/improve")]
    public async Task<ActionResult> ImproveToAdmin([FromForm] string email)
    {
        if (!await _roleManager.RoleExistsAsync("admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
        }
        
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest();
        
        await _userManager.AddToRoleAsync(user, "admin");
        return Ok();
    }
    
    [HttpPost]
    [Route("/decrease")]
    public async Task<ActionResult> RemoveFromAdmin([FromForm] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest();
        
        await _userManager.RemoveFromRoleAsync(user, "admin");
        return Ok();
    }
    
    [HttpDelete]
    [Route("/user/{email}")]
    public async Task<ActionResult> DeleteUser([FromRoute] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest();
        
        await _userManager.DeleteAsync(user);
        return Ok();
    }

    [HttpGet]
    [Route("/users")]
    public async Task<ActionResult> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }
    
    [HttpGet]
    [Route("/calculations")]
    public async Task<ActionResult> GetCalculations()
    {
        var calculations = await _calculationService.GetCalculations();
        return Ok(calculations);
    }
    
    [HttpGet]
    [Route("/calculations/{userId}")]
    public async Task<ActionResult> GetCalculationsForUser([FromRoute] string userId)
    {
        var calculations = await _calculationService.GetCalculations(userId);
        return Ok(calculations);
    }
    
    [HttpGet]
    [Route("/calculation/{id}")]
    public async Task<ActionResult> GetCalculation([FromRoute] string id)
    {
        var calculation = await _calculationService.GetCalculation(id);
        return Ok(calculation);
    }
    
    [HttpDelete]
    [Route("/calculation/{id}")]
    public async Task<ActionResult> DeleteCalculation([FromRoute] string id)
    {
        await _calculationService.DeleteCalculation(id);
        return Ok();
    }
    
    [HttpDelete]
    [Route("/calculations/{userId}")]
    public async Task<ActionResult> DeleteCalculationsForUser([FromRoute] string userId)
    {
        await _calculationService.DeleteAllCalculations(userId);
        return Ok();
    }
    
    
}