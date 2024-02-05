using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._304;

public class LC8 {
	[SectionPosition(1)] public C8_CertificationsAndClauses CertificationsAndClauses { get; set; } = new();
	[SectionPosition(2)] public List<C8C_CertificationsClausesContinuation> CertificationsClausesContinuation { get; set; } = new();
	[SectionPosition(3)] public List<SUP_SupplementaryInformation> SupplementaryInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LC8>(this);
		validator.Required(x => x.CertificationsAndClauses);
		validator.CollectionSize(x => x.CertificationsClausesContinuation, 0, 5);
		validator.CollectionSize(x => x.SupplementaryInformation, 0, 10);
		return validator.Results;
	}
}