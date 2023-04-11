using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G47")]
public class G47_StatementIdentification : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string StatementNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G47_StatementIdentification>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.StatementNumber);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.StatementNumber, 1, 16);
		return validator.Results;
	}
}