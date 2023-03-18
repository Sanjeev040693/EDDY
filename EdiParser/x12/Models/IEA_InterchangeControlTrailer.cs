﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("IEA")]
public class IEA_InterchangeControlTrailer : EdiX12Segment
{
    [Position(01)]
    public int? NumberOfIncludedFunctionalGroups { get; set; }

    [Position(02)]
    public string InterchangeControlNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<IEA_InterchangeControlTrailer>(this);
        validator.Required(x => x.NumberOfIncludedFunctionalGroups);
        validator.Required(x => x.InterchangeControlNumber);
        validator.Length(x => x.NumberOfIncludedFunctionalGroups, 1, 5);
        validator.Length(x => x.InterchangeControlNumber, 9);
        return validator.Results;
    }
}