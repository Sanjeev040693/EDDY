﻿using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._214;

public class CartonDetail
{
    [SectionPosition(1)]
    public CD3_CartonPackageDetail CartonPackageDetail { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();

    //[SectionPosition(4)]
    //public NM1

    [SectionPosition(5)]
    public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();

    [SectionPosition(6)]
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingAndQuantityData { get; set; }

    [SectionPosition(7)]
    public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();

    [SectionPosition(8)]
    public List<Party> Parties { get; set; } = new();

}