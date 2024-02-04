using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._218;

public class L2800 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<MCT_TariffAccessorialCharges> TariffAccessorialCharges { get; set; } = new();
	[SectionPosition(3)] public List<GY_Geography> Geography { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2800>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.TariffAccessorialCharges, 0, 99);
		validator.CollectionSize(x => x.Geography, 0, 99);
		return validator.Results;
	}
}
