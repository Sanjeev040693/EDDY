using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CAD")]
public class CAD_CarrierDetails : EdiX12Segment
{
	[Position(01)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string Routing { get; set; }

	[Position(06)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(07)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string ServiceLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAD_CarrierDetails>(this);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.AtLeastOneIsRequired(x=>x.Routing, x=>x.StandardCarrierAlphaCode);
		validator.ARequiresB(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ServiceLevelCode, 2);
		return validator.Results;
	}
}
