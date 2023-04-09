using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BVITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVI*GI*K*o*B0*uf";

		var expected = new BVI_BeverageInformation()
		{
			BeverageCategory = "GI",
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "o",
			CiderType = "B0",
			PreMixDrinkCode = "uf",
		};

		var actual = Map.MapObject<BVI_BeverageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("GI", true)]
	public void Validatation_RequiredBeverageCategory(string beverageCategory, bool isValidExpected)
	{
		var subject = new BVI_BeverageInformation();
		subject.BeverageCategory = beverageCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
