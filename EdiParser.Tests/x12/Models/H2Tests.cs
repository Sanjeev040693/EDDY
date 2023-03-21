﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class H2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "H2*I5*x";

        var expected = new H2_AdditionalHazardousMaterialDescription()
        {
            HazardousMaterialDescription = "I5",
            HazardousMaterialClassification = "x",
        };

        var actual = Map.MapObject<H2_AdditionalHazardousMaterialDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredHazardousMaterialDescription(string hazardousMaterialDescription, bool isValidExpected)
    {
        var subject = new H2_AdditionalHazardousMaterialDescription();
        subject.HazardousMaterialDescription = hazardousMaterialDescription;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}