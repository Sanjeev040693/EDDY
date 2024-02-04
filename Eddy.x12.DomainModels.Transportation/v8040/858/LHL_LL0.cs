using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._858;

public class LHL_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<LHL__LL0_LPI> LPI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.RateAndCharges, 0, 20);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.LPI, 0, 30);
		foreach (var item in LPI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
