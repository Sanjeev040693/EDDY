using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LH1")]
public class LH1_HazardousIdentificationInformation : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public int? LadingQuantity { get; set; }

	[Position(03)]
	public string UNNAIdentificationCode { get; set; }

	[Position(04)]
	public string HazardousMaterialsPage { get; set; }

	[Position(05)]
	public string CommodityCode { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(07)]
	public int? LadingQuantity2 { get; set; }

	[Position(08)]
	public string CompartmentIDCode { get; set; }

	[Position(09)]
	public string ResidueIndicatorCode { get; set; }

	[Position(10)]
	public string PackingGroupCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH1_HazardousIdentificationInformation>(this);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.LadingQuantity);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.UNNAIdentificationCode, 6);
		validator.Length(x => x.HazardousMaterialsPage, 1, 6);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.LadingQuantity2, 1, 7);
		validator.Length(x => x.CompartmentIDCode, 1);
		validator.Length(x => x.ResidueIndicatorCode, 1);
		validator.Length(x => x.PackingGroupCode, 1, 3);
		return validator.Results;
	}
}
