using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ETDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ETD*G*P*3A*9*N";

		var expected = new ETD_ExcessTransportationDetail()
		{
			ExcessTransportationReasonCode = "G",
			ExcessTransportationResponsibilityCode = "P",
			ReferenceIdentificationQualifier = "3A",
			ReferenceIdentification = "9",
			ReturnableContainerFreightPaymentResponsibilityCode = "N",
		};

		var actual = Map.MapObject<ETD_ExcessTransportationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validatation_RequiredExcessTransportationReasonCode(string excessTransportationReasonCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationResponsibilityCode = "P";
		subject.ExcessTransportationReasonCode = excessTransportationReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validatation_RequiredExcessTransportationResponsibilityCode(string excessTransportationResponsibilityCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "G";
		subject.ExcessTransportationResponsibilityCode = excessTransportationResponsibilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3A", "9", true)]
	[InlineData("", "9", false)]
	[InlineData("3A", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "G";
		subject.ExcessTransportationResponsibilityCode = "P";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}