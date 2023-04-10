using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;
using EdiParser.x12.Models.Elements;

namespace EdiParser.x12.Models;

[Segment("CTX")]
public class CTX_Context : EdiX12Segment
{
	[Position(01)]
	public C998_ContextIdentification ContextIdentification { get; set; }

	[Position(02)]
	public string SegmentIDCode { get; set; }

	[Position(03)]
	public int? SegmentPositionInTransactionSet { get; set; }

	[Position(04)]
	public string LoopIdentifierCode { get; set; }

	[Position(05)]
	public C030_PositionInSegment PositionInSegment { get; set; }

	[Position(06)]
	public C999_ReferenceInSegment ReferenceInSegment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTX_Context>(this);
		validator.Required(x=>x.ContextIdentification);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.SegmentPositionInTransactionSet, 1, 10);
		validator.Length(x => x.LoopIdentifierCode, 1, 6);
		return validator.Results;
	}
}
