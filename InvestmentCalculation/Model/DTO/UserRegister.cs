using System.ComponentModel.DataAnnotations;
using InvestmentCalculation.Data.Entities;

namespace InvestmentCalculation.Model.DTO;

public class UserRegister
{
    [Required]
    public string UserFirstName { get; init; }
    
    [Required]
    public string UserLastName { get; init; }

    public string? UserThirdName { get; init; }
    
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    
    [Required]
    public string Password { get; init; }
    
    public string? OrganizationName { get; init; }
    
    [Required]
    public string INN { get; init; }
    
    public string? CountryName { get; init; }
    
    public string? CityName { get; init; }
    
    public string? PositionInOrganization { get; init; }

    [Required]
    public string UserEconomyBranchName { get; init; }

    private ProjectUser _toProjectUser(UserRegister userRegister)
    {
        var user = new ProjectUser(UserFirstName,
            userRegister.UserFirstName,
            userRegister.UserLastName,
            userRegister.UserThirdName,
            userRegister.OrganizationName,
            userRegister.INN,
            userRegister.CountryName,
            userRegister.CityName,
            userRegister.PositionInOrganization,
            userRegister.UserEconomyBranchName);
        user.Email = Email;
        return user;
    }

    public static implicit operator ProjectUser(UserRegister userRegister) => userRegister._toProjectUser(userRegister);
}