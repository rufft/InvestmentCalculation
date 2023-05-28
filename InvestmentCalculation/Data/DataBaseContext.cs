using InvestmentCalculation.Data.Entities;
using InvestmentCalculation.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculation.Data;

public class DataBaseContext : IdentityDbContext<ProjectUser>
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    { }
    
    public DbSet<EconomyBranch> EconomyBranches { get; set; }
    public DbSet<MachineRequestInfo> MachineRequestInfos { get; set; }
    public DbSet<MoscowDistrict> MoscowDistricts { get; set; }
    public DbSet<Calculation> Calculations { get; set; }
    public DbSet<BusinessAccounting> BusinessAccountings { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<JurisprudenceCompanyForm> JurisprudenceCompanyForms { get; set; }
    public DbSet<PatentBusinesses> PatentBusinesses { get; set; }
}