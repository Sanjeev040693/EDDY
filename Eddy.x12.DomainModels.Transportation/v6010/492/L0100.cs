using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._492;

public class L0100 {
	[SectionPosition(1)] public SC_DocketSubLevel DocketSubLevel { get; set; } = new();
	[SectionPosition(2)] public DM_DemurrageDetentionStorageRate? DemurrageDetentionStorageRate { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.DocketSubLevel);
		return validator.Results;
	}
}