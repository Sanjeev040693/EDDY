using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DVI")]
public class DVI_DynamicVehicleInformation : EdiX12Segment
{
	[Position(01)]
	public string PriceIdentifierCode { get; set; }

	[Position(02)]
	public decimal? UnitPrice { get; set; }

	[Position(03)]
	public string CurrencyCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string Name { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string StateOrProvinceCode { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(11)]
	public string DateTimePeriod2 { get; set; }

	[Position(12)]
	public string LicensePlateTypeCode { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(14)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DVI_DynamicVehicleInformation>(this);
		validator.ARequiresB(x=>x.PriceIdentifierCode, x=>x.UnitPrice);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.ARequiresB(x=>x.CountryCode, x=>x.StateOrProvinceCode);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.LicensePlateTypeCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
