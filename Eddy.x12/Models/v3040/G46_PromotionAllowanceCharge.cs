using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("G46")]
public class G46_PromotionAllowanceCharge : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeCode { get; set; }

	[Position(02)]
	public string AllowanceOrChargeMethodOfHandlingCode { get; set; }

	[Position(03)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	[Position(06)]
	public string AllowanceChargePercentQualifier { get; set; }

	[Position(07)]
	public decimal? AllowanceOrChargePercent { get; set; }

	[Position(08)]
	public string ExceptionNumber { get; set; }

	[Position(09)]
	public string OptionNumber { get; set; }

	[Position(10)]
	public string FreeFormMessage { get; set; }

	[Position(11)]
	public string PriceIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G46_PromotionAllowanceCharge>(this);
		validator.Required(x=>x.AllowanceOrChargeCode);
		validator.Required(x=>x.AllowanceOrChargeMethodOfHandlingCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AllowanceOrChargeRate, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AllowanceChargePercentQualifier, x=>x.AllowanceOrChargePercent);
		validator.Length(x => x.AllowanceOrChargeCode, 1, 3);
		validator.Length(x => x.AllowanceOrChargeMethodOfHandlingCode, 2);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 9);
		validator.Length(x => x.AllowanceChargePercentQualifier, 1);
		validator.Length(x => x.AllowanceOrChargePercent, 1, 6);
		validator.Length(x => x.ExceptionNumber, 1, 16);
		validator.Length(x => x.OptionNumber, 1, 20);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.PriceIdentifierCode, 3);
		return validator.Results;
	}
}
