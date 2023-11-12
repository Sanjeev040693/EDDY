using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("RTE")]
public class RTE_RateInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? InterestRate { get; set; }

	[Position(02)]
	public decimal? InterestRate2 { get; set; }

	[Position(03)]
	public decimal? InterestRate3 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public int? NumberOfDays { get; set; }

	[Position(08)]
	public int? NumberOfDays2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTE_RateInformation>(this);
		validator.Required(x=>x.InterestRate);
		validator.Required(x=>x.InterestRate2);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.InterestRate2, 1, 6);
		validator.Length(x => x.InterestRate3, 1, 6);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.NumberOfDays2, 1, 3);
		return validator.Results;
	}
}
