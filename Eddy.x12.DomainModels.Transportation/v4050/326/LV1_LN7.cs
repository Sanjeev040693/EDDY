using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._326;

public class LV1_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LV1_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 9);
		return validator.Results;
	}
}
