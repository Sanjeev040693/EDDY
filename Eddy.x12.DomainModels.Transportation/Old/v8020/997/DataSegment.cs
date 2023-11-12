﻿using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._997;

public class DataSegment
{
    [SectionPosition(1)]
    public AK3_DataSegmentNote DataSegmentNote { get; set; }

    [SectionPosition(2)]
    public List<AK4_DataElementNote> DataElementNote { get; set; } = new();

}