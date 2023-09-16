using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("SN1")]
public class SN1_ItemDetailShipment : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? QuantityShippedToDate { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(07)]
	public string ReturnableContainerLoadMakeUpCode { get; set; }

	[Position(08)]
	public string LineItemStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SN1_ItemDetailShipment>(this);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.QuantityShippedToDate, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.ReturnableContainerLoadMakeUpCode, 1, 2);
		validator.Length(x => x.LineItemStatusCode, 2);
		return validator.Results;
	}
}
