using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._211;

public class L0200_L0220 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<SPO_ShipmentPurchaseOrderDetail> ShipmentPurchaseOrderDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0220>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 999999);
		validator.CollectionSize(x => x.ShipmentPurchaseOrderDetail, 0, 999999);
		return validator.Results;
	}
}
