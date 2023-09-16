using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TD3")]
public class TD3_CarrierDetailsEquipment : EdiX12Segment
{
	[Position(01)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string WeightQualifier { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(07)]
	public string OwnershipCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD3_CarrierDetailsEquipment>(this);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.ARequiresB(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.OwnershipCode, 1);
		return validator.Results;
	}
}
