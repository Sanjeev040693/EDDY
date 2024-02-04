using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._422;

public class LLX__LF9__LSCR_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LF9__LSCR_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 20);
		return validator.Results;
	}
}
