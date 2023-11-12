using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("PRJ")]
public class PRJ_MultifamilyHousingProject : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRJ_MultifamilyHousingProject>(this);
		validator.Required(x=>x.Name);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}
