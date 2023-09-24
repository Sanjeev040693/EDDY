using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("Y2")]
public class Y2_ContainerDetails : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfContainers { get; set; }

	[Position(02)]
	public string ContainerTypeRequestCode { get; set; }

	[Position(03)]
	public string TypeOfServiceCode { get; set; }

	[Position(04)]
	public string EquipmentType { get; set; }

	[Position(05)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(06)]
	public string TOFCIntermodalCodeQualifier { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string ContainerTermsCode { get; set; }

	[Position(09)]
	public string ContainerTermsCodeQualifier { get; set; }

	[Position(10)]
	public int? TotalStopoffs { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y2_ContainerDetails>(this);
		validator.Required(x=>x.NumberOfContainers);
		validator.Required(x=>x.EquipmentType);
		validator.Length(x => x.NumberOfContainers, 1, 4);
		validator.Length(x => x.ContainerTypeRequestCode, 1);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.TOFCIntermodalCodeQualifier, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ContainerTermsCode, 3);
		validator.Length(x => x.ContainerTermsCodeQualifier, 1);
		validator.Length(x => x.TotalStopoffs, 1, 2);
		return validator.Results;
	}
}
