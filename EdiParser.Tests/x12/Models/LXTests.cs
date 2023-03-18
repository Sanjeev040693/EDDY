﻿using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class LXTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LX*r";

        var expected = new LX_TransactionSetLineNumber()
        {
            AssignedNumber = "r",
        };

        var actual = Map.MapObject<LX_TransactionSetLineNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
}