using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("N4")]
public class N4_GeographicLocation : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string PostalCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string LocationQualifier { get; set; }

	[Position(06)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N4_GeographicLocation>(this);
		validator.AtLeastOneIsRequired(x=>x.CityName, x=>x.LocationQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 4, 9);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		return validator.Results;
	}
}
