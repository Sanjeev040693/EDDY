using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("R2C")]
public class R2C_DivisionBasis : EdiX12Segment
{
	[Position(01)]
	public string DivisionTypeCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public decimal? FactorAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R2C_DivisionBasis>(this);
		validator.Required(x=>x.DivisionTypeCode);
		validator.Length(x => x.DivisionTypeCode, 1);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.FactorAmount, 1, 9);
		return validator.Results;
	}
}
