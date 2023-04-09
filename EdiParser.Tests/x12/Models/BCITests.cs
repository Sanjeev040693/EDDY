using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCI*F*V*5*Wi*D0*E*h0*EZK";

		var expected = new BCI_BasicClaimInformation()
		{
			IndustryCode = "F",
			InsuranceTypeCode = "V",
			ReferenceIdentification = "5",
			StateOrProvinceCode = "Wi",
			DateTimePeriodFormatQualifier = "D0",
			DateTimePeriod = "E",
			ReportTypeCode = "h0",
			CurrencyCode = "EZK",
		};

		var actual = Map.MapObject<BCI_BasicClaimInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D0", "E", true)]
	[InlineData("", "E", false)]
	[InlineData("D0", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BCI_BasicClaimInformation();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
