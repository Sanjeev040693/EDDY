using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DPNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DPN*3*C*NP*6";

		var expected = new DPN_DependentInformation()
		{
			Number = 3,
			MaritalStatusCode = "C",
			EmploymentStatusCode = "NP",
			Number2 = 6,
		};

		var actual = Map.MapObject<DPN_DependentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new DPN_DependentInformation();
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}