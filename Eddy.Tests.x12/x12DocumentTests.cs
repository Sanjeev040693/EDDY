﻿namespace Eddy.x12.Tests;

public class x12DocumentTests
{
    private readonly string[] data;

    // Static constructor to ensure EdiSectionParserFactory.LoadSegmentProviders() 
    // is called once for the entire test run
    static x12DocumentTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    // Constructor to initialize data
    public x12DocumentTests()
    {
        data = new[]
        {
            "ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000003438*0*P*>~",
            "GS*SM*4405197800*999999999*20111219*1747*2100*X*004010~",
            "ST*204*0001~",
            "B2**XXXX**9999955559**PP~",
            "B2A*04~",
            "L11*NONPRIMARY*OK~",
            "NTE**FROZEN GOODS SET TO -10d F~",
            "N1*PF*XYZ CORP*9*9995555500000~",
            "N3*31875 SOLON RD~",
            "N4*SOLON*OH*44139~",
            "N7**NONE*********FF****5300~",
            "S5*1*CL*27800*L*2444*CA*1016*E~",
            "L11*9999001947*DO~",
            "L11*9999670098*CR~",
            "L11*9999001866*DO~",
            "L11*9999669887*CR~"
        };
    }

    [Fact]
    public void ValidDocument()
    {
        var subject = x12Document.Parse(string.Join(Environment.NewLine, data));
        Assert.True(subject.IsValid);
    }

    [Fact]
    public void InvalidB2()
    {
        data[3] = "B2**TOOLONGSCAC**9999955559**PP~";
        var subject = x12Document.Parse(string.Join(Environment.NewLine, data));
        Assert.False(subject.IsValid);
        Assert.Single(subject.ValidationErrors);
        Assert.Equal(4, subject.ValidationErrors[0].LineNumber);
    }


}