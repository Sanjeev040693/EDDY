using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("NFD")]
public class NFD_NutritionFactsPanelFooterStatement : EdiX12Segment
{
	[Position(01)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NFD_NutritionFactsPanelFooterStatement>(this);
		return validator.Results;
	}
}