using InvestmentCalculation.Data;
using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentCalculation.Controllers;

[Route("api")]
public class UserController : ControllerBase
{
    private readonly SignInManager<ProjectUser> _signInManager;
    private readonly UserManager<ProjectUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly DataBaseContext _context;
    public UserController(
        SignInManager<ProjectUser> signInManager,
        UserManager<ProjectUser> userManager,
        RoleManager<IdentityRole> roleManager, DataBaseContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromHeader] string email, [FromHeader] string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest();
        
        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        
        if (result.Succeeded)
            return Ok();
        
        return Unauthorized();
    }
    
    [HttpPost]
    [Authorize]
    [Route("logout")]
    public async Task<ActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] UserRegister userRegister)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        if (!await _roleManager.RoleExistsAsync("user"))
        {
            await _roleManager.CreateAsync(new IdentityRole("user"));
        }
        
        if (!await _roleManager.RoleExistsAsync("admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
        }

        ProjectUser user = userRegister;
        // add economy branch to user 
        var branch = _context.EconomyBranches.FirstOrDefault(x => x.Id == userRegister.UserEconomyBranchId);

        if (branch == null) return BadRequest();

        user.UserEconomyBranch = branch;
        
        var result = await _userManager.CreateAsync(user, userRegister.Password);
        
        if (!result.Succeeded) return BadRequest();
        
        await _userManager.AddToRoleAsync(user, "admin");
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    [Route("password")]
    public async Task<ActionResult> ChangePassword([FromBody] string oldPassword, [FromBody] string newPassword)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return BadRequest();
        
        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        
        if (!result.Succeeded) return BadRequest();
        
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    [Route("email")]
    public async Task<ActionResult> ChangeEmail([FromBody] string newEmail)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return BadRequest();
        
        var result = await _userManager.SetEmailAsync(user, newEmail);
        
        if (!result.Succeeded) return BadRequest();
        
        return Ok();
    }
    
    [HttpDelete]
    [Authorize]
    [Route("user/{email}")]
    public async Task<ActionResult> DeleteUser([FromRoute] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest();

        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return BadRequest();
        
        if (user.Id != currentUser.Id) return BadRequest();

        await _userManager.DeleteAsync(user);
        return Ok();
    }
}