using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._106;

public class L0400_L0405 {
	[SectionPosition(1)] public MS2_EquipmentOrContainerOwnerAndType EquipmentOrContainerOwnerAndType { get; set; } = new();
	[SectionPosition(2)] public AT9_TrailerOrContainerDimensionAndWeight? TrailerOrContainerDimensionAndWeight { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0405>(this);
		validator.Required(x => x.EquipmentOrContainerOwnerAndType);
		return validator.Results;
	}
}