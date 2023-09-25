using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SMR")]
public class SMR_CrossReference : EdiX12Segment
{
	[Position(01)]
	public string LocationQualifier { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMR_CrossReference>(this);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
