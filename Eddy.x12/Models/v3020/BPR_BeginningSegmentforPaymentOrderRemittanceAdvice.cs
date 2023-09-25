using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BPR")]
public class BPR_BeginningSegmentForPaymentOrderRemittanceAdvice : EdiX12Segment
{
	[Position(01)]
	public string TransactionHandlingCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string CreditDebitFlagCode { get; set; }

	[Position(04)]
	public string PaymentMethodCode { get; set; }

	[Position(05)]
	public string PaymentFormat { get; set; }

	[Position(06)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(07)]
	public string DFIIdentificationNumber { get; set; }

	[Position(08)]
	public string AccountNumberQualifierCode { get; set; }

	[Position(09)]
	public string AccountNumber { get; set; }

	[Position(10)]
	public string OriginatingCompanyIdentifier { get; set; }

	[Position(11)]
	public string OriginatingCompanySupplementalCode { get; set; }

	[Position(12)]
	public string DFIIDNumberQualifier2 { get; set; }

	[Position(13)]
	public string DFIIdentificationNumber2 { get; set; }

	[Position(14)]
	public string AccountNumberQualifierCode2 { get; set; }

	[Position(15)]
	public string AccountNumber2 { get; set; }

	[Position(16)]
	public string EffectiveEntryDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice>(this);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Required(x=>x.PaymentMethodCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier, x=>x.DFIIdentificationNumber);
		validator.ARequiresB(x=>x.AccountNumberQualifierCode, x=>x.AccountNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier2, x=>x.DFIIdentificationNumber2);
		validator.ARequiresB(x=>x.AccountNumberQualifierCode2, x=>x.AccountNumber2);
		validator.Length(x => x.TransactionHandlingCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.PaymentFormat, 1, 10);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumberQualifierCode, 2);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.OriginatingCompanyIdentifier, 10);
		validator.Length(x => x.OriginatingCompanySupplementalCode, 9);
		validator.Length(x => x.DFIIDNumberQualifier2, 2);
		validator.Length(x => x.DFIIdentificationNumber2, 3, 12);
		validator.Length(x => x.AccountNumberQualifierCode2, 2);
		validator.Length(x => x.AccountNumber2, 1, 35);
		validator.Length(x => x.EffectiveEntryDate, 6);
		return validator.Results;
	}
}
