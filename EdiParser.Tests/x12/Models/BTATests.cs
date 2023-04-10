using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTA*Up*cjye5K1k*H*6";

		var expected = new BTA_BeginningTaxAcknowledgment()
		{
			AcknowledgmentTypeCode = "Up",
			Date = "cjye5K1k",
			AmountQualifierCode = "H",
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<BTA_BeginningTaxAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("", false)]
	[InlineData("Up", true)]
	public void Validatation_RequiredAcknowledgmentTypeCode(string acknowledgmentTypeCode, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		subject.AcknowledgmentTypeCode = acknowledgmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("H", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("H", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BTA_BeginningTaxAcknowledgment();
		subject.AcknowledgmentTypeCode = "Up";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}