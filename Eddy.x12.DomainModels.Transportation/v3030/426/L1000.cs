using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._426;

public class L1000 {
	[SectionPosition(1)] public BNX_RailShipmentInformation RailShipmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<L1000_L1100> L1100 {get;set;} = new();
	[SectionPosition(5)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(6)] public List<N8A_AdditionalReferenceInformation> AdditionalReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(8)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(9)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(10)] public List<L1000_L1200> L1200 {get;set;} = new();
	[SectionPosition(11)] public List<L1000_L1300> L1300 {get;set;} = new();
	[SectionPosition(12)] public List<PRI_ExternalReferenceIdentifier> ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(13)] public List<L7A_ContractReferenceIdentifier> ContractReferenceIdentifier { get; set; } = new();
	[SectionPosition(14)] public List<L1000_L1400> L1400 {get;set;} = new();
	[SectionPosition(15)] public List<RE_RebillAtInterchange> RebillAtInterchange { get; set; } = new();
	[SectionPosition(16)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(17)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(18)] public List<L1000_L1500> L1500 {get;set;} = new();
	[SectionPosition(19)] public List<L1000_L1600> L1600 {get;set;} = new();
	[SectionPosition(20)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(21)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(22)] public GA_CanadianGrainInformation? CanadianGrainInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000>(this);
		validator.Required(x => x.RailShipmentInformation);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.WaybillReference, 1, 499);
		validator.CollectionSize(x => x.AdditionalReferenceInformation, 0, 499);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.ExternalReferenceIdentifier, 0, 12);
		validator.CollectionSize(x => x.ContractReferenceIdentifier, 0, 12);
		validator.CollectionSize(x => x.RebillAtInterchange, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.CustomsInformation, 0, 10);
		validator.CollectionSize(x => x.L1100, 1, 500);
		validator.CollectionSize(x => x.L1200, 1, 10);
		validator.CollectionSize(x => x.L1300, 0, 6);
		validator.CollectionSize(x => x.L1400, 1, 13);
		validator.CollectionSize(x => x.L1500, 0, 25);
		validator.CollectionSize(x => x.L1600, 0, 64);
		foreach (var item in L1100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1400) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1500) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1600) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
