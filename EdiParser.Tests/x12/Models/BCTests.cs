using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BC*4s*cxro7k4y*gBl2*5*A*RA*I";

		var expected = new BC_BeginningSegmentForContractCompletionStatus()
		{
			TransactionSetPurposeCode = "4s",
			Date = "cxro7k4y",
			Time = "gBl2",
			ReferenceIdentification = "5",
			ReferenceIdentification2 = "A",
			TransactionTypeCode = "RA",
			ActionCode = "I",
		};

		var actual = Map.MapObject<BC_BeginningSegmentForContractCompletionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("4s", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BC_BeginningSegmentForContractCompletionStatus();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
