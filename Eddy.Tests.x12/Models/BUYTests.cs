using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*0*X*9*6*7";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "0",
			SourceOfFundsCode = "X",
			MonetaryAmount = 9,
			PercentageAsDecimal = 6,
			PercentageAsDecimal2 = 7,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		subject.SourceOfFundsCode = "X";
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredSourceOfFundsCode(string sourceOfFundsCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		subject.LoanBuydownTypeCode = "0";
		subject.SourceOfFundsCode = sourceOfFundsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}