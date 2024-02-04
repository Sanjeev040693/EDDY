using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._435;

public class LSID_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingName> HazardousMaterialShippingName { get; set; } = new();
	[SectionPosition(4)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(5)] public List<LFH_FreeformHazardousMaterialInformation> FreeformHazardousMaterialInformation { get; set; } = new();
	[SectionPosition(6)] public List<LEP_EPARequiredData> EPARequiredData { get; set; } = new();
	[SectionPosition(7)] public LH4_CanadianDangerousRequirements? CanadianDangerousRequirements { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSID_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 50);
		validator.CollectionSize(x => x.HazardousMaterialShippingName, 0, 100);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 8);
		validator.CollectionSize(x => x.FreeformHazardousMaterialInformation, 0, 20);
		validator.CollectionSize(x => x.EPARequiredData, 0, 3);
		return validator.Results;
	}
}
