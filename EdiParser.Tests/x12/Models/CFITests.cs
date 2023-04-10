using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFI*M3*8U*D*AzT*e*J*BL";

		var expected = new CFI_CompensationFinancialInformation()
		{
			CodeCategory = "M3",
			AdjustmentReasonCode = "8U",
			AdjustmentReasonCodeCharacteristic = "D",
			MaintenanceTypeCode = "AzT",
			FrequencyCode = "e",
			SettlementTypeCode = "J",
			LateReasonCode = "BL",
		};

		var actual = Map.MapObject<CFI_CompensationFinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("M3", true)]
	public void Validatation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CFI_CompensationFinancialInformation();
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}