using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("B4")]
public class B4_BeginningSegmentForInquiryOrReply : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public int? InquiryRequestNumber { get; set; }

	[Position(03)]
	public string StatusCode { get; set; }

	[Position(04)]
	public string StatusDate { get; set; }

	[Position(05)]
	public string StatusTime { get; set; }

	[Position(06)]
	public string StatusLocation { get; set; }

	[Position(07)]
	public string EquipmentInitial { get; set; }

	[Position(08)]
	public string EquipmentNumber { get; set; }

	[Position(09)]
	public string EquipmentStatusCode { get; set; }

	[Position(10)]
	public string EquipmentType { get; set; }

	[Position(11)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B4_BeginningSegmentForInquiryOrReply>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.InquiryRequestNumber, 1, 3);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.StatusDate, 6);
		validator.Length(x => x.StatusTime, 4);
		validator.Length(x => x.StatusLocation, 3, 5);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		return validator.Results;
	}
}
