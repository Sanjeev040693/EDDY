﻿using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class HazMatContact
{
    [SectionPosition(1)]
    public G61_Contact Contact { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();

    [SectionPosition(4)]
    public List<HazMatInfo> HazMatInfo { get; set; } = new();
}