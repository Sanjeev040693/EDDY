using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ENE")]
public class ENE_ElectronicSystemsEnvironment : EdiX12Segment
{
	[Position(01)]
	public string CommunicationsEnvironmentCode { get; set; }

	[Position(02)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(03)]
	public string CommunicationNumber { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ENE_ElectronicSystemsEnvironment>(this);
		validator.Required(x=>x.CommunicationsEnvironmentCode);
		validator.Required(x=>x.CommunicationNumberQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Required(x=>x.CommunicationNumber);
		validator.Length(x => x.CommunicationsEnvironmentCode, 2);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		return validator.Results;
	}
}
