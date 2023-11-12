using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ST")]
public class ST_TransactionSetHeader : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string TransactionSetControlNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ST_TransactionSetHeader>(this);
		validator.Required(x=>x.TransactionSetIdentifierCode);
		validator.Required(x=>x.TransactionSetControlNumber);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		return validator.Results;
	}
}
