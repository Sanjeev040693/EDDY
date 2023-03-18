﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("AT1")]
public class AT1_BillOfLadingLineItemNumber : EdiX12Segment
{
    [Position(01)]
    public int? LadingLineItemNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AT1_BillOfLadingLineItemNumber>(this);
        validator.Required(x => x.LadingLineItemNumber);
        validator.Length(x => x.LadingLineItemNumber, 1, 6);
        return validator.Results;
    }
}