namespace InvestmentCalculation.Model;

public interface ITaxes
{
    float MeanProfitTax { get; set; }
    float MeanPropertyTax { get; set; }
    float MeanAreaRentTax { get; set; }
    float MeanPersonalIncomeTax { get; set; }
    float MeanTransportTax { get; set; }
    float MeanAnotherTaxes { get; set; }
}