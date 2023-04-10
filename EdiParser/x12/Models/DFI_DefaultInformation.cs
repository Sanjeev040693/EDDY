using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DFI")]
public class DFI_DefaultInformation : EdiX12Segment
{
	[Position(01)]
	public string StatusReasonCode { get; set; }

	[Position(02)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DFI_DefaultInformation>(this);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
