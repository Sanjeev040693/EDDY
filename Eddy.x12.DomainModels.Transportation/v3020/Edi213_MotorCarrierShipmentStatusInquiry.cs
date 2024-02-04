using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._213;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi213_MotorCarrierShipmentStatusInquiry {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B11_BeginningSegmentForShipmentStatusInquiry BeginningSegmentForShipmentStatusInquiry { get; set; } = new();
	[SectionPosition(3)] public C3_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(5)] public List<L10_Weight> Weight { get; set; } = new();
	[SectionPosition(6)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<K2_AdministrativeMessage> AdministrativeMessage { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi213_MotorCarrierShipmentStatusInquiry>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentStatusInquiry);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.Weight, 0, 5);
		validator.CollectionSize(x => x.AdministrativeMessage, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
