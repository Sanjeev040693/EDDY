using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("IDC")]
public class IDC_IdentificationCard : EdiX12Segment
{
	[Position(01)]
	public string PlanCoverageDescription { get; set; }

	[Position(02)]
	public string IdentificationCardTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IDC_IdentificationCard>(this);
		validator.Required(x=>x.PlanCoverageDescription);
		validator.Required(x=>x.IdentificationCardTypeCode);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.IdentificationCardTypeCode, 1);
		return validator.Results;
	}
}
