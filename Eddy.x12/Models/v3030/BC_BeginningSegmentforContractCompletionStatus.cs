using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BC")]
public class BC_BeginningSegmentForContractCompletionStatus : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BC_BeginningSegmentForContractCompletionStatus>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}