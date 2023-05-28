using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;
using Microsoft.AspNetCore.Identity;

namespace InvestmentCalculation.Data.Entities;

public class ProjectUser : IdentityUser
{
    public ProjectUser(string userName,
        string userFirstName,
        string userLastName,
        string? userThirdName,
        string? organizationName,
        string inn,
        string? countryName,
        string? cityName,
        string? positionInOrganization,
        string userEconomyBranchName) : base(userName)
    {
        UserFirstName = userFirstName;
        UserLastName = userLastName;
        UserThirdName = userThirdName;
        OrganizationName = organizationName;
        INN = inn;
        CountryName = countryName;
        CityName = cityName;
        PositionInOrganization = positionInOrganization;
        UserEconomyBranchName = userEconomyBranchName;
    }

    [Column("user_first_name")]
    public string UserFirstName { get; set; }
    
    [Column("user_last_name")]
    public string UserLastName { get; set; }

    [Column("user_third_name")]
    public string? UserThirdName { get; set; }
    
    [Column("organization_name")]
    public string? OrganizationName { get; set; }
    
    [Column("inn")]
    public string INN { get; set; }
    
    [Column("country_name")]
    public string? CountryName { get; set; }
    
    [Column("city_name")]
    public string? CityName { get; set; }
    
    [Column("position_in_organization")]
    public string? PositionInOrganization { get; set; }

    [Column("branch_of_the_economy")]
    public string UserEconomyBranchName { get; set; }

    [Column("investment_calculations")]
    public List<Calculation> Calculations { get; set; } = new();

    private ProjectUser() { }
}