using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SV3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV3**1*m**7*7*k*z*V*U*9";

		var expected = new SV3_DentalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 1,
			FacilityCodeValue = "m",
			OralCavityDesignation = null,
			ProsthesisCrownOrInlayCode = "7",
			Quantity = 7,
			Description = "k",
			CopayStatusCode = "z",
			ProviderAgreementCode = "V",
			YesNoConditionOrResponseCode = "U",
			DiagnosisCodePointer = 9,
		};

		var actual = Map.MapObject<SV3_DentalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV3_DentalService();

        if (compositeMedicalProcedureIdentifier != "")
            subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}