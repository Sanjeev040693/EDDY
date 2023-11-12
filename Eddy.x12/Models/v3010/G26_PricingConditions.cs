using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G26")]
public class G26_PricingConditions : EdiX12Segment
{
	[Position(01)]
	public string PriceConditionCode { get; set; }

	[Position(02)]
	public string DateQualifier { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string QuantityBasis { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G26_PricingConditions>(this);
		validator.Required(x=>x.PriceConditionCode);
		validator.Length(x => x.PriceConditionCode, 2);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.QuantityBasis, 3);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		return validator.Results;
	}
}
