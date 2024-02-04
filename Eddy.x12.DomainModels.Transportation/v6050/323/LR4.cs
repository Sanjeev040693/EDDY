using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._323;

public class LR4 {
	[SectionPosition(1)] public R4_PortOrTerminal PortOrTerminal { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR4>(this);
		validator.Required(x => x.PortOrTerminal);
		validator.CollectionSize(x => x.DateTimeReference, 0, 15);
		validator.CollectionSize(x => x.EventDetail, 1, 5);
		return validator.Results;
	}
}
