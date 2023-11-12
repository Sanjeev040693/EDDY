using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("X4")]
public class X4_CustomsReleaseInformation : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string EntryTypeCode { get; set; }

	[Position(04)]
	public string EntryNumber { get; set; }

	[Position(05)]
	public string ReleaseIssueDate { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string DispositionCode { get; set; }

	[Position(08)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(11)]
	public string EquipmentInitial { get; set; }

	[Position(12)]
	public string EquipmentNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X4_CustomsReleaseInformation>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ReleaseIssueDate);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.DispositionCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.EntryTypeCode, 2);
		validator.Length(x => x.EntryNumber, 1, 15);
		validator.Length(x => x.ReleaseIssueDate, 6);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.DispositionCode, 2);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		return validator.Results;
	}
}
