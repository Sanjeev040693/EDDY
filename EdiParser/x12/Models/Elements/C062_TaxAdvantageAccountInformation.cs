﻿using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C062")]
public class C062_TaxAdvantageAccountInformation : EdiX12Component
{
    [Position(00)]
    public string AccountRelationshipCode { get; set; }

    [Position(01)]
    public string AccountNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C062_TaxAdvantageAccountInformation>(this);
        validator.Required(x => x.AccountRelationshipCode);
        validator.Length(x => x.AccountRelationshipCode, 1, 2);
        validator.Length(x => x.AccountNumber, 1, 35);
        return validator.Results;
    }
}