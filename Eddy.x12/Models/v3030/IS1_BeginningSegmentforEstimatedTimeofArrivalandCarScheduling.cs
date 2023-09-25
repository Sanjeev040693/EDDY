using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("IS1")]
public class IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string LoadEmptyStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.LoadEmptyStatusCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		return validator.Results;
	}
}
