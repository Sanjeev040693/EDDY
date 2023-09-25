using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("THE")]
public class THE_ScreenTheaterIdentification : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<THE_ScreenTheaterIdentification>(this);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.Name);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.Quantity);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
