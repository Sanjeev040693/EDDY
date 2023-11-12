using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("U2")]
public class U2_UltimateConsigneeAddress : EdiX12Segment
{
	[Position(01)]
	public string AdditionalNameAddressData { get; set; }

	[Position(02)]
	public string AdditionalNameAddressData2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<U2_UltimateConsigneeAddress>(this);
		validator.Required(x=>x.AdditionalNameAddressData);
		validator.Length(x => x.AdditionalNameAddressData, 1, 30);
		validator.Length(x => x.AdditionalNameAddressData2, 1, 30);
		return validator.Results;
	}
}
