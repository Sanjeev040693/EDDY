using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PO3")]
public class PO3_AdditionalItemDetail : EdiX12Segment
{
	[Position(01)]
	public string ChangeReasonCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string PriceIdentifierCode { get; set; }

	[Position(04)]
	public decimal? UnitPrice { get; set; }

	[Position(05)]
	public string BasisOfUnitPriceCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO3_AdditionalItemDetail>(this);
		validator.Required(x=>x.ChangeReasonCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitPrice, x=>x.PriceIdentifierCode, x=>x.BasisOfUnitPriceCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.ChangeReasonCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.BasisOfUnitPriceCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
