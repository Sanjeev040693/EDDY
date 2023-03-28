﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;

namespace EdiParser.Tests.x12.Models;

public class SPOTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "SPO*IXtz54B2mI8mOM2w8fwzEA*C8yVe5Z3segwMSlTgVR6qhu5mgvlZo*8E*2*y*7*LCL*rNCMLYcN0g2U06tZztCTYThxTyqe9c";

        var expected = new SPO_ShipmentPurchaseOrderDetail()
        {
            PurchaseOrderNumber = "IXtz54B2mI8mOM2w8fwzEA",
            ReferenceIdentification = "C8yVe5Z3segwMSlTgVR6qhu5mgvlZo",
            UnitOrBasisForMeasurementCode = "8E",
            Quantity = 2,
            WeightUnitCode = "y",
            Weight = 7,
            ApplicationErrorConditionCode = "LCL",
            ReferenceIdentification2 = "rNCMLYcN0g2U06tZztCTYThxTyqe9c",
        };

        var actual = Map.MapObject<SPO_ShipmentPurchaseOrderDetail>(x12Line, MapOptionsForTesting.x12Default);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("IXtz54B2mI8mOM2w8fwzEA", true)]
    public void Validatation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
    {
        var subject = new SPO_ShipmentPurchaseOrderDetail();
        subject.PurchaseOrderNumber = purchaseOrderNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SPO_ShipmentPurchaseOrderDetail();
        subject.PurchaseOrderNumber = "IXtz54B2mI8mOM2w8fwzEA";
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
    {
        var subject = new SPO_ShipmentPurchaseOrderDetail();
        subject.PurchaseOrderNumber = "IXtz54B2mI8mOM2w8fwzEA";
        subject.WeightUnitCode = weightUnitCode;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}