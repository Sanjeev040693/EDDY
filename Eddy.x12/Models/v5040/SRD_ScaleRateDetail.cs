using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("SRD")]
public class SRD_ScaleRateDetail : EdiX12Segment
{
	[Position(01)]
	public string DistanceQualifier { get; set; }

	[Position(02)]
	public string RateBasisNumber { get; set; }

	[Position(03)]
	public string DistanceQualifier2 { get; set; }

	[Position(04)]
	public string RateBasisNumber2 { get; set; }

	[Position(05)]
	public decimal? FreightRate { get; set; }

	[Position(06)]
	public decimal? FreightRate2 { get; set; }

	[Position(07)]
	public decimal? FreightRate3 { get; set; }

	[Position(08)]
	public decimal? FreightRate4 { get; set; }

	[Position(09)]
	public decimal? FreightRate5 { get; set; }

	[Position(10)]
	public decimal? FreightRate6 { get; set; }

	[Position(11)]
	public decimal? FreightRate7 { get; set; }

	[Position(12)]
	public decimal? FreightRate8 { get; set; }

	[Position(13)]
	public decimal? FreightRate9 { get; set; }

	[Position(14)]
	public decimal? FreightRate10 { get; set; }

	[Position(15)]
	public decimal? FreightRate11 { get; set; }

	[Position(16)]
	public decimal? FreightRate12 { get; set; }

	[Position(17)]
	public decimal? FreightRate13 { get; set; }

	[Position(18)]
	public decimal? FreightRate14 { get; set; }

	[Position(19)]
	public decimal? FreightRate15 { get; set; }

	[Position(20)]
	public decimal? FreightRate16 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SRD_ScaleRateDetail>(this);
		validator.Required(x=>x.DistanceQualifier);
		validator.Required(x=>x.RateBasisNumber);
		validator.Required(x=>x.FreightRate);
		validator.Length(x => x.DistanceQualifier, 1);
		validator.Length(x => x.RateBasisNumber, 1, 6);
		validator.Length(x => x.DistanceQualifier2, 1);
		validator.Length(x => x.RateBasisNumber2, 1, 6);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.FreightRate2, 1, 15);
		validator.Length(x => x.FreightRate3, 1, 15);
		validator.Length(x => x.FreightRate4, 1, 15);
		validator.Length(x => x.FreightRate5, 1, 15);
		validator.Length(x => x.FreightRate6, 1, 15);
		validator.Length(x => x.FreightRate7, 1, 15);
		validator.Length(x => x.FreightRate8, 1, 15);
		validator.Length(x => x.FreightRate9, 1, 15);
		validator.Length(x => x.FreightRate10, 1, 15);
		validator.Length(x => x.FreightRate11, 1, 15);
		validator.Length(x => x.FreightRate12, 1, 15);
		validator.Length(x => x.FreightRate13, 1, 15);
		validator.Length(x => x.FreightRate14, 1, 15);
		validator.Length(x => x.FreightRate15, 1, 15);
		validator.Length(x => x.FreightRate16, 1, 15);
		return validator.Results;
	}
}