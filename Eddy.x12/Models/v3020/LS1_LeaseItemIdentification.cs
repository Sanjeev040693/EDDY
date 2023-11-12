using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LS1")]
public class LS1_LeaseItemIdentification : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string AssignedIdentification { get; set; }

	[Position(03)]
	public string ChangeOrResponseTypeCode { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public string ProductServiceID2 { get; set; }

	[Position(06)]
	public string ProductServiceID3 { get; set; }

	[Position(07)]
	public string ProductServiceID4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LS1_LeaseItemIdentification>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.ProductServiceID3, 1, 30);
		validator.Length(x => x.ProductServiceID4, 1, 30);
		return validator.Results;
	}
}
