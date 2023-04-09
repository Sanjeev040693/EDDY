using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BCO")]
public class BCO_BeginningSegmentForProcurementNotices : EdiX12Segment 
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string RequestForQuoteReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string ContractStatusCode { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string Date3 { get; set; }

	[Position(08)]
	public string AcknowledgmentTypeCode { get; set; }

	[Position(09)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(10)]
	public string ReferenceIdentification2 { get; set; }

	[Position(11)]
	public string TransactionTypeCode { get; set; }

	[Position(12)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCO_BeginningSegmentForProcurementNotices>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.RequestForQuoteReferenceNumber, 1, 45);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ContractStatusCode, 2);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.AcknowledgmentTypeCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
