﻿using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AK3")]
public class AK3_DataSegmentNote : EdiX12Segment
{
    [Position(01)]
    public string SegmentIDCode { get; set; }

    [Position(02)]
    public int? SegmentPositionInTransactionSet { get; set; }

    [Position(03)]
    public string LoopIdentifierCode { get; set; }

    [Position(04)]
    public string SegmentSyntaxErrorCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AK3_DataSegmentNote>(this);
        validator.Required(x => x.SegmentIDCode);
        validator.Required(x => x.SegmentPositionInTransactionSet);
        validator.Length(x => x.SegmentIDCode, 2, 3);
        validator.Length(x => x.SegmentPositionInTransactionSet, 1, 10);
        validator.Length(x => x.LoopIdentifierCode, 1, 6);
        validator.Length(x => x.SegmentSyntaxErrorCode, 1, 3);
        return validator.Results;
    }
}