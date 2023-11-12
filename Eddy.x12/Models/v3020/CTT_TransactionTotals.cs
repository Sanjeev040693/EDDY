using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CTT")]
public class CTT_TransactionTotals : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfLineItems { get; set; }

	[Position(02)]
	public decimal? HashTotal { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(05)]
	public decimal? Volume { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTT_TransactionTotals>(this);
		validator.Required(x=>x.NumberOfLineItems);
		validator.ARequiresB(x=>x.Weight, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.Volume, x=>x.UnitOfMeasurementCode2);
		validator.Length(x => x.NumberOfLineItems, 1, 6);
		validator.Length(x => x.HashTotal, 1, 10);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
