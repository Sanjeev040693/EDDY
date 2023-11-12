using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020.Composites;

namespace Eddy.x12.Models.v7020;

[Segment("INS")]
public class INS_InsuredBenefit : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string IndividualRelationshipCode { get; set; }

	[Position(03)]
	public string MaintenanceTypeCode { get; set; }

	[Position(04)]
	public string MaintenanceReasonCode { get; set; }

	[Position(05)]
	public string BenefitStatusCode { get; set; }

	[Position(06)]
	public C052_MedicareStatusCode MedicareStatusCode { get; set; }

	[Position(07)]
	public string ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode { get; set; }

	[Position(08)]
	public string EmploymentStatusCode { get; set; }

	[Position(09)]
	public string StudentStatusCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(11)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(12)]
	public string DateTimePeriod { get; set; }

	[Position(13)]
	public string ConfidentialityCode { get; set; }

	[Position(14)]
	public string CityName { get; set; }

	[Position(15)]
	public string StateOrProvinceCode { get; set; }

	[Position(16)]
	public string CountryCode { get; set; }

	[Position(17)]
	public int? Number { get; set; }

	[Position(18)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(19)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(20)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	[Position(21)]
	public string YesNoConditionOrResponseCode6 { get; set; }

	[Position(22)]
	public string YesNoConditionOrResponseCode7 { get; set; }

	[Position(23)]
	public string YesNoConditionOrResponseCode8 { get; set; }

	[Position(24)]
	public string YesNoConditionOrResponseCode9 { get; set; }

	[Position(25)]
	public string YesNoConditionOrResponseCode10 { get; set; }

	[Position(26)]
	public string YesNoConditionOrResponseCode11 { get; set; }

	[Position(27)]
	public string YesNoConditionOrResponseCode12 { get; set; }

	[Position(28)]
	public string YesNoConditionOrResponseCode13 { get; set; }

	[Position(29)]
	public string YesNoConditionOrResponseCode14 { get; set; }

	[Position(30)]
	public string YesNoConditionOrResponseCode15 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INS_InsuredBenefit>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.IndividualRelationshipCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.BenefitStatusCode, 1);
		validator.Length(x => x.ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode, 1, 2);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.StudentStatusCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ConfidentialityCode, 1);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode6, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode7, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode8, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode9, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode10, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode11, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode12, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode13, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode14, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode15, 1);
		return validator.Results;
	}
}
