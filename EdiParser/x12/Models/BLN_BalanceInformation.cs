using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BLN")]
public class BLN_BalanceInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLN_BalanceInformation>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}