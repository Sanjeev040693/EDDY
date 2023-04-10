using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BHT*zE1H*UR*t*1fg3ZYEz*7Nu5*yC";

		var expected = new BHT_BeginningOfHierarchicalTransaction()
		{
			HierarchicalStructureCode = "zE1H",
			TransactionSetPurposeCode = "UR",
			ReferenceIdentification = "t",
			Date = "1fg3ZYEz",
			Time = "7Nu5",
			TransactionTypeCode = "yC",
		};

		var actual = Map.MapObject<BHT_BeginningOfHierarchicalTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("zE1H", true)]
	public void Validatation_RequiredHierarchicalStructureCode(string hierarchicalStructureCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		subject.TransactionSetPurposeCode = "UR";
		subject.HierarchicalStructureCode = hierarchicalStructureCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UR", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		subject.HierarchicalStructureCode = "zE1H";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}