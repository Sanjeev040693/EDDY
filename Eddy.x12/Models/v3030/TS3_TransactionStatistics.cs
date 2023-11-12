using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("TS3")]
public class TS3_TransactionStatistics : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string FacilityCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(10)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount7 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount8 { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount9 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount10 { get; set; }

	[Position(15)]
	public decimal? MonetaryAmount11 { get; set; }

	[Position(16)]
	public decimal? MonetaryAmount12 { get; set; }

	[Position(17)]
	public decimal? MonetaryAmount13 { get; set; }

	[Position(18)]
	public decimal? MonetaryAmount14 { get; set; }

	[Position(19)]
	public decimal? MonetaryAmount15 { get; set; }

	[Position(20)]
	public decimal? MonetaryAmount16 { get; set; }

	[Position(21)]
	public decimal? MonetaryAmount17 { get; set; }

	[Position(22)]
	public decimal? MonetaryAmount18 { get; set; }

	[Position(23)]
	public decimal? Quantity2 { get; set; }

	[Position(24)]
	public decimal? MonetaryAmount19 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TS3_TransactionStatistics>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.FacilityCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.FacilityCode, 1, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.MonetaryAmount5, 1, 15);
		validator.Length(x => x.MonetaryAmount6, 1, 15);
		validator.Length(x => x.MonetaryAmount7, 1, 15);
		validator.Length(x => x.MonetaryAmount8, 1, 15);
		validator.Length(x => x.MonetaryAmount9, 1, 15);
		validator.Length(x => x.MonetaryAmount10, 1, 15);
		validator.Length(x => x.MonetaryAmount11, 1, 15);
		validator.Length(x => x.MonetaryAmount12, 1, 15);
		validator.Length(x => x.MonetaryAmount13, 1, 15);
		validator.Length(x => x.MonetaryAmount14, 1, 15);
		validator.Length(x => x.MonetaryAmount15, 1, 15);
		validator.Length(x => x.MonetaryAmount16, 1, 15);
		validator.Length(x => x.MonetaryAmount17, 1, 15);
		validator.Length(x => x.MonetaryAmount18, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount19, 1, 15);
		return validator.Results;
	}
}
