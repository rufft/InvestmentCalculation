using System.ComponentModel.DataAnnotations.Schema;
using InvestmentCalculation.Model;

namespace InvestmentCalculation.Data.Entities;

public class MoscowDistrict : IIdentifier
{
    public MoscowDistrict(string districtName, float meanPricePerSquareMeter)
    {
        DistrictName = districtName;
        MeanPricePerSquareMeter = meanPricePerSquareMeter;
    }

    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }

    [Column("district_name")] public string DistrictName { get; }

    [Column("mean_price_per_square_meter")]
    public float MeanPricePerSquareMeter { get; set; }

    private MoscowDistrict() { }
}