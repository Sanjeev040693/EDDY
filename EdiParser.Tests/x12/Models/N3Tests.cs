﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class N3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N3*8*M";

        var expected = new N3_PartyLocation()
        {
            AddressInformation = "8",
            AddressInformation2 = "M",
        };

        var actual = Map.MapObject<N3_PartyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
    {
        var subject = new N3_PartyLocation();
        subject.AddressInformation = addressInformation;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}