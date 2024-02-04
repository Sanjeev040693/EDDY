using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._414;

public class LCTC_LCIC {
	[SectionPosition(1)] public CIC_CarInformationControl CarInformationControl { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<LCTC__LCIC_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCTC_LCIC>(this);
		validator.Required(x => x.CarInformationControl);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 2);
		validator.CollectionSize(x => x.LLX, 0, 99);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
