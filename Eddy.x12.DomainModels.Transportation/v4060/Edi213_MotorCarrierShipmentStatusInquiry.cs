using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;
using Eddy.x12.DomainModels.Transportation.v4060._213;

namespace Eddy.x12.DomainModels.Transportation.v4060;

public class Edi213_MotorCarrierShipmentStatusInquiry {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B11_BeginningSegmentForShipmentStatusInquiry BeginningSegmentForShipmentStatusInquiry { get; set; } = new();
	[SectionPosition(3)] public C3_Currency? CurrencyIdentifier { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<L10_WeightInformation> WeightInformation { get; set; } = new();
	[SectionPosition(6)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(7)] public List<K2_AdministrativeMessage> AdministrativeMessage { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi213_MotorCarrierShipmentStatusInquiry>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentStatusInquiry);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.WeightInformation, 0, 5);
		validator.CollectionSize(x => x.AdministrativeMessage, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 5);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
