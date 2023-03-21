﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.Tests.x12.Models;

public class AT1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AT1*3";

        var expected = new AT1_BillOfLadingLineItemNumber()
        {
            LadingLineItemNumber = 3,
        };

        var actual = Map.MapObject<AT1_BillOfLadingLineItemNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
    {
        var subject = new AT1_BillOfLadingLineItemNumber();
        if (ladingLineItemNumber > 0)
            subject.LadingLineItemNumber = ladingLineItemNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}