using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._204;

public class L0400 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(4)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<LAD_LadingDetail> LadingDetail { get; set; } = new();
	[SectionPosition(6)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	[SectionPosition(7)] public List<H2_AdditionalHazardousMaterialDescription> AdditionalHazardousMaterialDescription { get; set; } = new();
	[SectionPosition(8)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(9)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	[SectionPosition(10)] public List<L4_Measurement> Measurement { get; set; } = new();
	[SectionPosition(11)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(12)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(13)] public List<L0400_L0405> L0405 {get;set;} = new();
	[SectionPosition(14)] public List<L0400_L0410> L0410 {get;set;} = new();
}
