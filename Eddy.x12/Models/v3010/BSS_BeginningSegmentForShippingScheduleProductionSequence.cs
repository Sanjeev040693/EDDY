using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BSS")]
public class BSS_BeginningSegmentForShippingScheduleProductionSequence : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ScheduleTypeQualifier { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string Date3 { get; set; }

	[Position(07)]
	public string ReleaseNumber { get; set; }

	[Position(08)]
	public string ReferenceNumber2 { get; set; }

	[Position(09)]
	public string ContractNumber { get; set; }

	[Position(10)]
	public string PurchaseOrderNumber { get; set; }

	[Position(11)]
	public string ScheduleQuantityQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSS_BeginningSegmentForShippingScheduleProductionSequence>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ScheduleTypeQualifier);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Date3);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ScheduleTypeQualifier, 2);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ScheduleQuantityQualifier, 1);
		return validator.Results;
	}
}