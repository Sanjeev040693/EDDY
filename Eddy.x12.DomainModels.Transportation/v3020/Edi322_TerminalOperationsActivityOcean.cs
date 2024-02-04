using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._322;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi322_TerminalOperationsActivityOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(3)] public V4_CargoLocationReference? CargoLocationReference { get; set; }
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public M7_SealNumbers? SealNumbers { get; set; }
	[SectionPosition(6)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(7)] public W2_EquipmentIdentification? EquipmentIdentification { get; set; }
	[SectionPosition(8)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(9)] public Q5_StatusDetails? StatusDetails { get; set; }
	[SectionPosition(10)] public Y7_Priority? Priority { get; set; }
	[SectionPosition(11)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(12)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(13)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(14)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(15)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(16)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(17)] public List<LL0> LL0 {get;set;} = new();
	[SectionPosition(18)] public List<L3_TotalWeightAndCharges> TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(19)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi322_TerminalOperationsActivityOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 30);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.Name, 0, 3);
		validator.CollectionSize(x => x.Remarks, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.TotalWeightAndCharges, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR4, 1, 20);
		validator.CollectionSize(x => x.LL0, 0, 999);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
