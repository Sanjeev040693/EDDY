using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEF*7*b*aw*I*y*t";

		var expected = new DEF_DelayedRepayment()
		{
			DelayedRepaymentQualifierCode = "7",
			DelayedRepaymentReasonCode = "b",
			DateTimePeriodFormatQualifier = "aw",
			DateTimePeriod = "I",
			InterestPaymentCode = "y",
			YesNoConditionOrResponseCode = "t",
		};

		var actual = Map.MapObject<DEF_DelayedRepayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validatation_RequiredDelayedRepaymentQualifierCode(string delayedRepaymentQualifierCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		subject.DelayedRepaymentReasonCode = "b";
		subject.DateTimePeriodFormatQualifier = "aw";
		subject.DateTimePeriod = "I";
		subject.DelayedRepaymentQualifierCode = delayedRepaymentQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validatation_RequiredDelayedRepaymentReasonCode(string delayedRepaymentReasonCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		subject.DelayedRepaymentQualifierCode = "7";
		subject.DateTimePeriodFormatQualifier = "aw";
		subject.DateTimePeriod = "I";
		subject.DelayedRepaymentReasonCode = delayedRepaymentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aw", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		subject.DelayedRepaymentQualifierCode = "7";
		subject.DelayedRepaymentReasonCode = "b";
		subject.DateTimePeriod = "I";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		subject.DelayedRepaymentQualifierCode = "7";
		subject.DelayedRepaymentReasonCode = "b";
		subject.DateTimePeriodFormatQualifier = "aw";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
