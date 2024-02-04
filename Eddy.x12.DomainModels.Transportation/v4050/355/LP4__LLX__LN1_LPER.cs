using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._355;

public class LP4__LLX__LN1_LPER {
	[SectionPosition(1)] public PER_AdministrativeCommunicationsContact AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LN1_LPER>(this);
		validator.Required(x => x.AdministrativeCommunicationsContact);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
