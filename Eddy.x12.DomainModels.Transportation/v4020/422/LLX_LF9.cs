using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._422;

public class LLX_LF9 {
	[SectionPosition(1)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(2)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(3)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LF9_LSCO> LSCO {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LF9>(this);
		validator.Required(x => x.OriginStation);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.RouteInformation, 1, 10);
		validator.CollectionSize(x => x.LSCO, 1, 9999);
		foreach (var item in LSCO) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
