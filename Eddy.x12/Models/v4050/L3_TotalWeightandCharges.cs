using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("L3")]
public class L3_TotalWeightAndCharges : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightQualifier { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string AmountCharged { get; set; }

	[Position(06)]
	public string Advances { get; set; }

	[Position(07)]
	public string PrepaidAmount { get; set; }

	[Position(08)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(09)]
	public decimal? Volume { get; set; }

	[Position(10)]
	public string VolumeUnitQualifier { get; set; }

	[Position(11)]
	public int? LadingQuantity { get; set; }

	[Position(12)]
	public string WeightUnitCode { get; set; }

	[Position(13)]
	public string TariffNumber { get; set; }

	[Position(14)]
	public string DeclaredValue { get; set; }

	[Position(15)]
	public string RateValueQualifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L3_TotalWeightAndCharges>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.WeightQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.ARequiresB(x=>x.WeightUnitCode, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DeclaredValue, x=>x.RateValueQualifier2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.AmountCharged, 1, 12);
		validator.Length(x => x.Advances, 1, 9);
		validator.Length(x => x.PrepaidAmount, 1, 9);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.DeclaredValue, 2, 12);
		validator.Length(x => x.RateValueQualifier2, 2);
		return validator.Results;
	}
}
