﻿using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("LAD")]
public class LAD_LadingDetail : EdiX12Segment
{
    [Position(01)]
    public string PackagingFormCode { get; set; }

    [Position(02)]
    public int? LadingQuantity { get; set; }

    [Position(03)]
    public string WeightUnitCode { get; set; }

    [Position(04)]
    public decimal? UnitWeight { get; set; }

    [Position(05)]
    public string WeightUnitCode2 { get; set; }

    [Position(06)]
    public decimal? Weight { get; set; }

    [Position(07)]
    public string ProductServiceIDQualifier { get; set; }

    [Position(08)]
    public string ProductServiceID { get; set; }

    [Position(09)]
    public string ProductServiceIDQualifier2 { get; set; }

    [Position(10)]
    public string ProductServiceID2 { get; set; }

    [Position(11)]
    public string ProductServiceIDQualifier3 { get; set; }

    [Position(12)]
    public string ProductServiceID3 { get; set; }

    [Position(13)]
    public string LadingDescription { get; set; }

    [Position(14)]
    public decimal? LadingValue { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LAD_LadingDetail>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.PackagingFormCode, x => x.LadingQuantity);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode, x => x.UnitWeight);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode2, x => x.Weight);
        validator.IfOneIsFilled_AllAreRequired(x => x.ProductServiceIDQualifier, x => x.ProductServiceID);
        validator.IfOneIsFilled_AllAreRequired(x => x.ProductServiceIDQualifier2, x => x.ProductServiceID2);
        validator.IfOneIsFilled_AllAreRequired(x => x.ProductServiceIDQualifier3, x => x.ProductServiceID3);
        validator.Length(x => x.PackagingFormCode, 3);
        validator.Length(x => x.LadingQuantity, 1, 7);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.UnitWeight, 1, 8);
        validator.Length(x => x.WeightUnitCode2, 1);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.ProductServiceIDQualifier, 2);
        validator.Length(x => x.ProductServiceID, 1, 80);
        validator.Length(x => x.ProductServiceIDQualifier2, 2);
        validator.Length(x => x.ProductServiceID2, 1, 80);
        validator.Length(x => x.ProductServiceIDQualifier3, 2);
        validator.Length(x => x.ProductServiceID3, 1, 80);
        validator.Length(x => x.LadingDescription, 1, 50);
        validator.Length(x => x.LadingValue, 2, 9);
        return validator.Results;
    }
}