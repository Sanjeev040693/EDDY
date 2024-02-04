using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._210;

public class L0300 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(5)] public List<L0300_L0310> L0310 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.L0310, 0, 2);
		foreach (var item in L0310) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
