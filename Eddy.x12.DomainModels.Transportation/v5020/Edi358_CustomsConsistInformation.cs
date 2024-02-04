using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Transportation.v5020._358;

namespace Eddy.x12.DomainModels.Transportation.v5020;

public class Edi358_CustomsConsistInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public List<VEH_VehicleInformation> VehicleInformation { get; set; } = new();
	[SectionPosition(4)] public List<CII_ConveyanceInsuranceInformation> ConveyanceInsuranceInformation { get; set; } = new();
	[SectionPosition(5)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(6)] public List<LP4> LP4 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi358_CustomsConsistInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.CollectionSize(x => x.VehicleInformation, 0, 10);
		validator.CollectionSize(x => x.ConveyanceInsuranceInformation, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNM1, 0, 999);
		validator.CollectionSize(x => x.LP4, 1, 20);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LP4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
