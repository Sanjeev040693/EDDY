using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W27")]
public class W27_CarrierDetail : EdiX12Segment
{
	[Position(01)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string Routing { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(05)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(06)]
	public string EquipmentInitial { get; set; }

	[Position(07)]
	public string EquipmentNumber { get; set; }

	[Position(08)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(09)]
	public string SpecialHandlingCode { get; set; }

	[Position(10)]
	public string CarrierRouteChangeReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W27_CarrierDetail>(this);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.CarrierRouteChangeReasonCode, 2);
		return validator.Results;
	}
}