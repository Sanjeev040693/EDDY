using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*8A*J1HqcHzn*d*Mml7LkDd*gE*i*R*0b*Z1*9*7*AB>1";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "8A",
			Date = "J1HqcHzn",
			ContractNumber = "d",
			Date2 = "Mml7LkDd",
			ContractTypeCode = "gE",
			Description = "i",
			ReferenceIdentification = "R",
			ProgramTypeCode = "0b",
			SecurityLevelCode = "Z1",
			PercentageAsDecimal = 9,
			PercentageAsDecimal2 = 7,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure()
            {
				UnitOrBasisForMeasurementCode = "AB",
				Exponent = 1
            },
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("8A", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		subject.Date = "J1HqcHzn";
		subject.ContractNumber = "d";
		subject.Date2 = "Mml7LkDd";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J1HqcHzn", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		subject.TransactionSetPurposeCode = "8A";
		subject.ContractNumber = "d";
		subject.Date2 = "Mml7LkDd";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validatation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		subject.TransactionSetPurposeCode = "8A";
		subject.Date = "J1HqcHzn";
		subject.Date2 = "Mml7LkDd";
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mml7LkDd", true)]
	public void Validatation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		subject.TransactionSetPurposeCode = "8A";
		subject.Date = "J1HqcHzn";
		subject.ContractNumber = "d";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}