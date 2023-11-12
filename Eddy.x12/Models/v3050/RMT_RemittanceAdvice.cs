using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("RMT")]
public class RMT_RemittanceAdvice : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(09)]
	public string AdjustmentReasonCode { get; set; }

	[Position(10)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RMT_RemittanceAdvice>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.MonetaryAmount5, 1, 15);
		validator.Length(x => x.MonetaryAmount6, 1, 15);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}