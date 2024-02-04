using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._358;

public class LP4_LMBL {
	[SectionPosition(1)] public MBL_BillOfLading BillOfLading { get; set; } = new();
	[SectionPosition(2)] public List<VID_VehicleID> VehicleID { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LMBL>(this);
		validator.Required(x => x.BillOfLading);
		validator.CollectionSize(x => x.VehicleID, 0, 500);
		return validator.Results;
	}
}
