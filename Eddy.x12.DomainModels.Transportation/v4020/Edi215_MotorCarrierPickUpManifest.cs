using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._215;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi215_MotorCarrierPickUpManifest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification? TransportationCarrierIdentification { get; set; }
	[SectionPosition(4)] public C3_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(7)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(8)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi215_MotorCarrierPickUpManifest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 10);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0200, 1, 999999);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
