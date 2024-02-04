using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._304;

public class LLX__LL0_LCTP {
	[SectionPosition(1)] public CTP_PricingInformation PricingInformation { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LCTP>(this);
		validator.Required(x => x.PricingInformation);
		return validator.Results;
	}
}
