using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BAT")]
public class BAT_Batch : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string Time { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string BatchTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAT_Batch>(this);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.BatchTypeCode, 2);
		return validator.Results;
	}
}
