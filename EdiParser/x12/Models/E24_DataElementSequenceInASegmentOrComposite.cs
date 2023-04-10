using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("E24")]
public class E24_DataElementSequenceInASegmentOrComposite : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? PositionInSegmentOrComposite { get; set; }

	[Position(03)]
	public string DataElementReferenceCode { get; set; }

	[Position(04)]
	public string RequirementDesignatorCode { get; set; }

	[Position(05)]
	public string DataElementUsageTypeCode { get; set; }

	[Position(06)]
	public int? NoteIdentificationNumber { get; set; }

	[Position(07)]
	public int? Count { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E24_DataElementSequenceInASegmentOrComposite>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.PositionInSegmentOrComposite);
		validator.Required(x=>x.DataElementReferenceCode);
		validator.Required(x=>x.RequirementDesignatorCode);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.PositionInSegmentOrComposite, 1, 2);
		validator.Length(x => x.DataElementReferenceCode, 1, 4);
		validator.Length(x => x.RequirementDesignatorCode, 1);
		validator.Length(x => x.DataElementUsageTypeCode, 1);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		validator.Length(x => x.Count, 1, 9);
		return validator.Results;
	}
}
