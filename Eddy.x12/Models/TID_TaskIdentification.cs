using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TID")]
public class TID_TaskIdentification : EdiX12Segment
{
	[Position(01)]
	public string TaskIDQualifier { get; set; }

	[Position(02)]
	public string TaskIdentifier { get; set; }

	[Position(03)]
	public string RelationshipTaskIdentifier { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string WorkStatusCode { get; set; }

	[Position(06)]
	public string ActionCode { get; set; }

	[Position(07)]
	public string ReferenceIdentification { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	[Position(09)]
	public string ReportingStructureIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TID_TaskIdentification>(this);
		validator.Required(x=>x.TaskIDQualifier);
		validator.Length(x => x.TaskIDQualifier, 2);
		validator.Length(x => x.TaskIdentifier, 1, 20);
		validator.Length(x => x.RelationshipTaskIdentifier, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.WorkStatusCode, 1, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReportingStructureIdentifier, 1, 3);
		return validator.Results;
	}
}
