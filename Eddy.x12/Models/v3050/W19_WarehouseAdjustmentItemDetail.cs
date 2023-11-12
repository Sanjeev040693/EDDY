using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("W19")]
public class W19_WarehouseAdjustmentItemDetail : EdiX12Segment
{
	[Position(01)]
	public string QuantityOrStatusAdjustmentReasonCode { get; set; }

	[Position(02)]
	public decimal? CreditDebitQuantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string UPCCaseCode { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(08)]
	public string ProductServiceID2 { get; set; }

	[Position(09)]
	public string WarehouseLotNumber { get; set; }

	[Position(10)]
	public decimal? Weight { get; set; }

	[Position(11)]
	public string WeightQualifier { get; set; }

	[Position(12)]
	public string WeightUnitCode { get; set; }

	[Position(13)]
	public decimal? Weight2 { get; set; }

	[Position(14)]
	public string WeightQualifier2 { get; set; }

	[Position(15)]
	public string WeightUnitCode2 { get; set; }

	[Position(16)]
	public string InventoryTransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W19_WarehouseAdjustmentItemDetail>(this);
		validator.Required(x=>x.QuantityOrStatusAdjustmentReasonCode);
		validator.Required(x=>x.CreditDebitQuantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.QuantityOrStatusAdjustmentReasonCode, 2);
		validator.Length(x => x.CreditDebitQuantity, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.InventoryTransactionTypeCode, 1, 2);
		return validator.Results;
	}
}
