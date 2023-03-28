﻿using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._8020._997;

public class TransactionSetResponseHeader
{
    [SectionPosition(1)] public AK2_TransactionSetResponseHeader Details { get; set; }

    [SectionPosition(2)] public List<DataSegment> DataSegments { get; set; } = new();

    [SectionPosition(3)] public AK5_TransactionSetResponseTrailer TransactionSetResponseTrailer { get; set; }
}