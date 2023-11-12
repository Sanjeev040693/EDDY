using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ZC")]
public class ZC_CorrectionOrChangeReferenceInformation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string EquipmentInitial { get; set; }

	[Position(04)]
	public string EquipmentNumber { get; set; }

	[Position(05)]
	public string TransactionReferenceNumber { get; set; }

	[Position(06)]
	public string TransactionReferenceDate { get; set; }

	[Position(07)]
	public string CorrectionIndicator { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZC_CorrectionOrChangeReferenceInformation>(this);
		validator.Required(x=>x.CorrectionIndicator);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.TransactionReferenceNumber, 2, 16);
		validator.Length(x => x.TransactionReferenceDate, 6);
		validator.Length(x => x.CorrectionIndicator, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
