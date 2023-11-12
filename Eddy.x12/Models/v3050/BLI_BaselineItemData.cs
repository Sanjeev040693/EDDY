using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BLI")]
public class BLI_BaselineItemData : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string PriceIdentifierCode { get; set; }

	[Position(06)]
	public decimal? UnitPrice { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(09)]
	public string ProductServiceID2 { get; set; }

	[Position(10)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(11)]
	public string ProductServiceID3 { get; set; }

	[Position(12)]
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(13)]
	public string ProductServiceID4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLI_BaselineItemData>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceIdentifierCode, x=>x.UnitPrice);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode2, x=>x.UnitPrice);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier4, x=>x.ProductServiceID4);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 40);
		return validator.Results;
	}
}
