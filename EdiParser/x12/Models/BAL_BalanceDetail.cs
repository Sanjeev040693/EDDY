using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("BAL")]
public class BAL_BalanceDetail : EdiX12Segment 
{
	[Position(01)]
	public string BalanceTypeCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAL_BalanceDetail>(this);
		validator.Required(x=>x.BalanceTypeCode);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.BalanceTypeCode, 1, 2);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
