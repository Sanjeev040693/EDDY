using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._126;

public class LBVA_LVAD {
	[SectionPosition(1)] public VAD_VehicleAdviceDetail VehicleAdviceDetail { get; set; } = new();
	[SectionPosition(2)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBVA_LVAD>(this);
		validator.Required(x => x.VehicleAdviceDetail);
		validator.CollectionSize(x => x.TariffReference, 0, 5);
		return validator.Results;
	}
}