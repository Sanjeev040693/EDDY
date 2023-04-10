using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class E10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E10*z*8MV*dE*v*6";

		var expected = new E10_TransactionSetGrouping()
		{
			MaintenanceOperationCode = "z",
			TransactionSetIdentifierCode = "8MV",
			FunctionalIdentifierCode = "dE",
			Description = "v",
			NoteIdentificationNumber = 6,
		};

		var actual = Map.MapObject<E10_TransactionSetGrouping>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.TransactionSetIdentifierCode = "8MV";
		subject.FunctionalIdentifierCode = "dE";
		subject.Description = "v";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8MV", true)]
	public void Validatation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "z";
		subject.FunctionalIdentifierCode = "dE";
		subject.Description = "v";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dE", true)]
	public void Validatation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "z";
		subject.TransactionSetIdentifierCode = "8MV";
		subject.Description = "v";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validatation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "z";
		subject.TransactionSetIdentifierCode = "8MV";
		subject.FunctionalIdentifierCode = "dE";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}