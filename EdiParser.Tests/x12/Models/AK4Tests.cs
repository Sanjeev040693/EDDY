﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class AK4Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK4*1*WpWQ*COl*SEyjYoeuTHDb0bAw0ArPIePN6tlVBrVxKRa4nTnmB3j7uUCOIKcZsgK82nB2HC2rzQkogd0ix5rMQCthfMKePlIDWWgNhqjjpoQ";

        var expected = new AK4_DataElementNote()
        {
            PositionInSegment = new C030_PositionInSegment() { ElementPositionInSegment = 1 },
            DataElementReferenceCode = "WpWQ",
            DataElementSyntaxErrorCode = "COl",
            CopyOfBadDataElement = "SEyjYoeuTHDb0bAw0ArPIePN6tlVBrVxKRa4nTnmB3j7uUCOIKcZsgK82nB2HC2rzQkogd0ix5rMQCthfMKePlIDWWgNhqjjpoQ",
        };

        var actual = Map.MapObject<AK4_DataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredPositionInSegment(int positionInSegment, bool isValidExpected)
    {
        var subject = new AK4_DataElementNote();
        subject.DataElementSyntaxErrorCode = "CO1";
        if (positionInSegment > 0)
            subject.PositionInSegment = new C030_PositionInSegment() { ElementPositionInSegment = positionInSegment };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("COl", true)]
    public void Validatation_RequiredDataElementSyntaxErrorCode(string dataElementSyntaxErrorCode, bool isValidExpected)
    {
        var subject = new AK4_DataElementNote();
        subject.PositionInSegment = new C030_PositionInSegment() { ElementPositionInSegment = 1 };
        subject.DataElementSyntaxErrorCode = dataElementSyntaxErrorCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}