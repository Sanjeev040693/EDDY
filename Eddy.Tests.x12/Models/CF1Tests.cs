using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CF1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF1*r*vK*kZVZEehD*5*9*mZLhEpWv";

		var expected = new CF1_BeginningSegmentForSummaryFreightBillManifest()
		{
			MasterReferenceLinkNumber = "r",
			StandardCarrierAlphaCode = "vK",
			Date = "kZVZEehD",
			Count = 5,
			Amount = "9",
			Date2 = "mZLhEpWv",
		};

		var actual = Map.MapObject<CF1_BeginningSegmentForSummaryFreightBillManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new CF1_BeginningSegmentForSummaryFreightBillManifest();
		subject.StandardCarrierAlphaCode = "vK";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vK", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CF1_BeginningSegmentForSummaryFreightBillManifest();
		subject.MasterReferenceLinkNumber = "r";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}