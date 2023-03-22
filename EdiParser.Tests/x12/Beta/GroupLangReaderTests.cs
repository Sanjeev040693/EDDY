﻿using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Beta;

public class GroupLangReaderTests
{
    // [Fact]
    // public void FullExample()
    // {
    //     var subject =
    //         @"+++
    //           +BillOfLading (AT5,RTT,C3)
    //           +Parties (N1,N2,N3,N4,L11,G61)
    //           +EquipmentDetails (N7, N7A, N7B, MEA, M7)
    //           +Stop (S5,L11,G62,AT8,LAD,NTE,PLD)
    //             +BillOfLadingHandlingRequirements (AT5,RTT,C3)
    //             +Parties (N1,N2,N3,N4,G61)
    //             +ShipmentData (L5,AT8)
    //               +HandlingRequirements (AT5,RTT,C3)
    //               +Contact (G61,L11,LH6)
    //                 +Hazmat (LH1,LH2,LH3,LFH,LEP,LH4,LHT)
    //               +EquipmentDetails(N7,N7A,N7B,MEA,M7)
    //             +StopOrderInformation(OID,G62,LAD)
    //                +OrderDetails(L5,AT8,L4) 
    //                  +Contact(G61,L11,LH6)
    //                    +HazMat (LH1,LH2,LH3,LFH,LEP,LH4,LHT)";
    //
    //     Assert.Fail("Not implemented");
    // }

    [Fact]
    public void ParseBasic()
    {
        var subject =
            @"+BillOfLading (AT5,RTT,C3)
              +Parties (N1,N2,N3,N4,L11,G61)";
           

        var groups = GroupLang.ToGroups(subject);
        Assert.Equal(2, groups.Length);
        
        Assert.Equal("BillOfLading", groups[0].Name);
        Assert.Equal(3, groups[0].AllowedTypes.Count);
        Assert.Equal(typeof(AT5_BillOfLadingHandlingRequirements), groups[0].AllowedTypes[0]);
        Assert.Equal(typeof(RTT_FreightRateInformation), groups[0].AllowedTypes[1]);
        Assert.Equal(typeof(C3_CurrencyIdentifier), groups[0].AllowedTypes[2]);

        Assert.Equal("Parties", groups[1].Name);
        Assert.Equal(6, groups[1].AllowedTypes.Count);
        Assert.Equal(typeof(N1_PartyIdentification), groups[1].AllowedTypes[0]);
        Assert.Equal(typeof(N2_AdditionalNameInformation), groups[1].AllowedTypes[1]);
        Assert.Equal(typeof(N3_PartyLocation), groups[1].AllowedTypes[2]);
        Assert.Equal(typeof(N4_GeographicLocation), groups[1].AllowedTypes[3]);
        Assert.Equal(typeof(L11_BusinessInstructionsAndReferenceNumber), groups[1].AllowedTypes[4]);
        Assert.Equal(typeof(G61_Contact), groups[1].AllowedTypes[5]);
    }
    //
    // [Fact]
    // public void ParseChild()
    // {
    //     var subject =
    //         @"+BillOfLading (AT5,RTT,C3)
    //             +Parties (N1,N2,N3,N4,L11,G61)";
    //
    //
    //     var groups = GroupLang.ToGroups(subject);
    //     Assert.Equal(1, groups.Length);
    //
    //     Assert.Equal("BillOfLading", groups[0].Name);
    //     Assert.Equal(3, groups[0].AllowedTypes.Count);
    //     Assert.Equal(typeof(AT5_BillOfLadingHandlingRequirements), groups[0].AllowedTypes[0]);
    //     Assert.Equal(typeof(RTT_FreightRateInformation), groups[0].AllowedTypes[1]);
    //     Assert.Equal(typeof(C3_CurrencyIdentifier), groups[0].AllowedTypes[2]);
    //
    //     var subRule = groups[0].SubRules[0];
    //     Assert.Equal("Parties", subRule.Name);
    //     Assert.Equal(6, subRule.AllowedTypes.Count);
    //     Assert.Equal(typeof(N1_PartyIdentification), subRule.AllowedTypes[0]);
    //     Assert.Equal(typeof(N2_AdditionalNameInformation), subRule.AllowedTypes[1]);
    //     Assert.Equal(typeof(N3_PartyLocation), subRule.AllowedTypes[2]);
    //     Assert.Equal(typeof(N4_GeographicLocation), subRule.AllowedTypes[3]);
    //     Assert.Equal(typeof(L11_BusinessInstructionsAndReferenceNumber), subRule.AllowedTypes[4]);
    //     Assert.Equal(typeof(G61_Contact), subRule.AllowedTypes[5]);
    // }
}