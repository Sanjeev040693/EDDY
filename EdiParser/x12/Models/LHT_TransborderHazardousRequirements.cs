﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("LHT")]
public class LHT_TransborderHazardousRequirements : EdiX12Segment
{
    [Position(01)]
    public string HazardousClassificationCode { get; set; }

    [Position(02)]
    public string HazardousPlacardNotationCode { get; set; }

    [Position(03)]
    public string HazardousEndorsementCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LHT_TransborderHazardousRequirements>(this);
        validator.Length(x => x.HazardousClassificationCode, 1, 30);
        validator.Length(x => x.HazardousPlacardNotationCode, 14, 40);
        validator.Length(x => x.HazardousEndorsementCode, 4, 25);
        return validator.Results;
    }
}