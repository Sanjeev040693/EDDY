using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G93")]
public class G93_PriceBracketIdentification : EdiX12Segment
{
	[Position(01)]
	public string PriceBracketIdentifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	[Position(05)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(06)]
	public string PriceIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G93_PriceBracketIdentification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		return validator.Results;
	}
}
