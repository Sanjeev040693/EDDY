using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._204;

public class L0300_L0380 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public N7A_AccessorialEquipmentDetails? AccessorialEquipmentDetails { get; set; }
	[SectionPosition(3)] public N7B_AdditionalEquipmentDetails? AdditionalEquipmentDetails { get; set; }
	[SectionPosition(4)] public MEA_Measurements? Measurements { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0380>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 2);
		return validator.Results;
	}
}
