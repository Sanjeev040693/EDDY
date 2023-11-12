using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SLN")]
public class SLN_SublineItemDetail : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string AssignedIdentification2 { get; set; }

	[Position(03)]
	public string ConfigurationCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(06)]
	public decimal? UnitPrice { get; set; }

	[Position(07)]
	public string BasisOfUnitPriceCode { get; set; }

	[Position(08)]
	public string SublinePriceChangeCodeID { get; set; }

	[Position(09)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(10)]
	public string ProductServiceID { get; set; }

	[Position(11)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(12)]
	public string ProductServiceID2 { get; set; }

	[Position(13)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(14)]
	public string ProductServiceID3 { get; set; }

	[Position(15)]
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(16)]
	public string ProductServiceID4 { get; set; }

	[Position(17)]
	public string ProductServiceIDQualifier5 { get; set; }

	[Position(18)]
	public string ProductServiceID5 { get; set; }

	[Position(19)]
	public string ProductServiceIDQualifier6 { get; set; }

	[Position(20)]
	public string ProductServiceID6 { get; set; }

	[Position(21)]
	public string ProductServiceIDQualifier7 { get; set; }

	[Position(22)]
	public string ProductServiceID7 { get; set; }

	[Position(23)]
	public string ProductServiceIDQualifier8 { get; set; }

	[Position(24)]
	public string ProductServiceID8 { get; set; }

	[Position(25)]
	public string ProductServiceIDQualifier9 { get; set; }

	[Position(26)]
	public string ProductServiceID9 { get; set; }

	[Position(27)]
	public string ProductServiceIDQualifier10 { get; set; }

	[Position(28)]
	public string ProductServiceID10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SLN_SublineItemDetail>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Required(x=>x.ConfigurationCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.AssignedIdentification, 1, 6);
		validator.Length(x => x.AssignedIdentification2, 1, 6);
		validator.Length(x => x.ConfigurationCode, 1);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.BasisOfUnitPriceCode, 2);
		validator.Length(x => x.SublinePriceChangeCodeID, 1);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier5, 2);
		validator.Length(x => x.ProductServiceID5, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier6, 2);
		validator.Length(x => x.ProductServiceID6, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier7, 2);
		validator.Length(x => x.ProductServiceID7, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier8, 2);
		validator.Length(x => x.ProductServiceID8, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier9, 2);
		validator.Length(x => x.ProductServiceID9, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier10, 2);
		validator.Length(x => x.ProductServiceID10, 1, 30);
		return validator.Results;
	}
}
