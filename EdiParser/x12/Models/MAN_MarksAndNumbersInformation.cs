﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("MAN")]
public class MAN_MarksAndNumbersInformation : EdiX12Segment
{
    [Position(01)]
    public string MarksAndNumbersQualifier { get; set; }

    [Position(02)]
    public string MarksAndNumbers { get; set; }

    [Position(03)]
    public string MarksAndNumbers2 { get; set; }

    [Position(04)]
    public string MarksAndNumbersQualifier2 { get; set; }

    [Position(05)]
    public string MarksAndNumbers3 { get; set; }

    [Position(06)]
    public string MarksAndNumbers4 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<MAN_MarksAndNumbersInformation>(this);
        validator.Required(x => x.MarksAndNumbersQualifier);
        validator.Required(x => x.MarksAndNumbers);
        validator.IfOneIsFilled_AllAreRequired(x => x.MarksAndNumbersQualifier2, x => x.MarksAndNumbers3);
        validator.ARequiresB(x => x.MarksAndNumbers4, x => x.MarksAndNumbers3);
        validator.Length(x => x.MarksAndNumbersQualifier, 1, 2);
        validator.Length(x => x.MarksAndNumbers, 1, 48);
        validator.Length(x => x.MarksAndNumbers2, 1, 48);
        validator.Length(x => x.MarksAndNumbersQualifier2, 1, 2);
        validator.Length(x => x.MarksAndNumbers3, 1, 48);
        validator.Length(x => x.MarksAndNumbers4, 1, 48);
        return validator.Results;
    }
}