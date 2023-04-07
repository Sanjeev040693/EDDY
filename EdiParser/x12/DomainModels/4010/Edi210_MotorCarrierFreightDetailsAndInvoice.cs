﻿using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Internals;
using EdiParser.x12.Models;
using EdiParser.x12.DomainModels._4010._210;

namespace EdiParser.x12.DomainModels._4010;

public class Edi210_MotorCarrierFreightDetailsAndInvoice
{
    //Header
    [SectionPosition(1)] public B3_BeginningSegmentForCarriersInvoice Details { get; set; } = new();
    [SectionPosition(2)] public C2_BankID BankIdentification { get; set; }
    [SectionPosition(3)] public C3_CurrencyIdentifier Currency { get; set; }
    [SectionPosition(4)] public ITD_TermsOfSaleDeferredTermsOfSale TermsOfSale { get; set; }
    [SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ReferenceInformation { get; set; } = new();
    [SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
    [SectionPosition(7)] public List<R3_RouteInformationMotor> RouteInformation { get; set; } = new();
    [SectionPosition(8)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
    [SectionPosition(9)] public List<K1_Remarks> Remarks { get; set; } = new();
    [SectionPosition(10)] public List<Party> Parties { get; set; } = new();
    [SectionPosition(11)] public List<EdiParser.x12.DomainModels._8020._210.EquipmentDetails> EquipmentDetails { get; set; } = new();
    [SectionPosition(12)] public List<OrderDetail> OrderDetails{ get; set; } = new();

    //Detail
    [SectionPosition(13)] public List<StopOffDetails> Stops { get; set; } = new();
    [SectionPosition(13)] public List<EdiParser.x12.DomainModels._8020._210.TransactionSet> Transactions { get; set; } = new();

    //Summary
    [SectionPosition(14)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; }


    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "210";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }

}