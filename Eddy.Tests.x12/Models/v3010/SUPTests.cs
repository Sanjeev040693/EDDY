using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SUPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUP*Vhc*uh*N";

		var expected = new SUP_SupplementaryInformation()
		{
			SupplementaryInformationQualifier = "Vhc",
			CertificationClauseCode = "uh",
			FreeFormMessage = "N",
		};

		var actual = Map.MapObject<SUP_SupplementaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vhc", true)]
	public void Validation_RequiredSupplementaryInformationQualifier(string supplementaryInformationQualifier, bool isValidExpected)
	{
		var subject = new SUP_SupplementaryInformation();
		subject.SupplementaryInformationQualifier = supplementaryInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
