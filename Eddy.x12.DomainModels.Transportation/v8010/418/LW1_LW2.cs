using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._418;

public class LW1_LW2 {
	[SectionPosition(1)] public W2_EquipmentIdentification EquipmentIdentification { get; set; } = new();
	[SectionPosition(2)] public List<W3_ConsigneeInformation> ConsigneeInformation { get; set; } = new();
	[SectionPosition(3)] public List<IMA_InterchangeMoveAuthority> InterchangeMoveAuthority { get; set; } = new();
	[SectionPosition(4)] public W4_ConsignorInformation? ConsignorInformation { get; set; }
	[SectionPosition(5)] public List<W5_CarrierAndRouteInformation> CarrierAndRouteInformation { get; set; } = new();
	[SectionPosition(6)] public List<W6_SpecialHandlingInformation> SpecialHandlingInformation { get; set; } = new();
	[SectionPosition(7)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(8)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(9)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(10)] public List<LW1__LW2_LLH1> LLH1 {get;set;} = new();
	[SectionPosition(11)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(12)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(13)] public LH2_HazardousClassificationInformation? HazardousClassificationInformation { get; set; }
	[SectionPosition(14)] public LHR_HazardousMaterialIdentifyingReferenceNumbers? HazardousMaterialIdentifyingReferenceNumbers { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LW1_LW2>(this);
		validator.Required(x => x.EquipmentIdentification);
		validator.CollectionSize(x => x.ConsigneeInformation, 0, 7);
		validator.CollectionSize(x => x.InterchangeMoveAuthority, 0, 3);
		validator.CollectionSize(x => x.CarrierAndRouteInformation, 0, 4);
		validator.CollectionSize(x => x.SpecialHandlingInformation, 0, 6);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.LLH1, 0, 1000);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
