using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._322;

public class LN7_LR4 {
	[SectionPosition(1)] public R4_Port Port { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7_LR4>(this);
		validator.Required(x => x.Port);
		validator.CollectionSize(x => x.DateTimeReference, 0, 15);
		return validator.Results;
	}
}
