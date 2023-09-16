using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SER")]
public class SER_ServiceCharges : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? UnitPrice { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string PriceIdentifierCode { get; set; }

	[Position(09)]
	public string PaymentMethodCode { get; set; }

	[Position(10)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(11)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SER_ServiceCharges>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.MonetaryAmount2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.PaymentMethodCode, 1);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
