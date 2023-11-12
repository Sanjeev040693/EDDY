using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("ACK")]
public class ACK_LineItemAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string LineItemStatusCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string RequestReferenceNumber { get; set; }

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
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(14)]
	public string ProductServiceID4 { get; set; }

	[Position(15)]
	public string ProductServiceIDQualifier5 { get; set; }

	[Position(16)]
	public string ProductServiceID5 { get; set; }

	[Position(17)]
	public string ProductServiceIDQualifier6 { get; set; }

	[Position(18)]
	public string ProductServiceID6 { get; set; }

	[Position(19)]
	public string ProductServiceIDQualifier7 { get; set; }

	[Position(20)]
	public string ProductServiceID7 { get; set; }

	[Position(21)]
	public string ProductServiceIDQualifier8 { get; set; }

	[Position(22)]
	public string ProductServiceID8 { get; set; }

	[Position(23)]
	public string ProductServiceIDQualifier9 { get; set; }

	[Position(24)]
	public string ProductServiceID9 { get; set; }

	[Position(25)]
	public string ProductServiceIDQualifier10 { get; set; }

	[Position(26)]
	public string ProductServiceID10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ACK_LineItemAcknowledgment>(this);
		validator.Required(x=>x.LineItemStatusCode);
		validator.ARequiresB(x=>x.Quantity, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.Date);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier4, x=>x.ProductServiceID4);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier5, x=>x.ProductServiceID5);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier6, x=>x.ProductServiceID6);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier7, x=>x.ProductServiceID7);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier8, x=>x.ProductServiceID8);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier9, x=>x.ProductServiceID9);
		validator.ARequiresB(x=>x.ProductServiceIDQualifier10, x=>x.ProductServiceID10);
		validator.Length(x => x.LineItemStatusCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
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
