using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._352;

public class LP4 {
	[SectionPosition(1)] public P4_PortOfDischargeInformation PortOfDischargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<LP4_LM14> LM14 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortOfDischargeInformation);
		validator.CollectionSize(x => x.LM14, 1, 999);
		foreach (var item in LM14) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
