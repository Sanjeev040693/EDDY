using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._204;

public class L0400 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
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
	[SectionPosition(13)] public List<L0400_L0410> L0410 {get;set;} = new();
	[SectionPosition(14)] public List<L0400_L0420> L0420 {get;set;} = new();
	[SectionPosition(15)] public List<L0400_L0430> L0430 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 300);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 30);
		validator.CollectionSize(x => x.LadingDetail, 0, 999);
		validator.CollectionSize(x => x.HazardousMaterial, 0, 3);
		validator.CollectionSize(x => x.AdditionalHazardousMaterialDescription, 0, 2);
		validator.CollectionSize(x => x.LineItemQuantityAndWeight, 0, 10);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		validator.CollectionSize(x => x.Measurement, 0, 10);
		validator.CollectionSize(x => x.TariffReference, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.L0410, 0, 99);
		validator.CollectionSize(x => x.L0420, 0, 999999);
		validator.CollectionSize(x => x.L0430, 0, 999999);
		foreach (var item in L0410) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0420) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0430) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
