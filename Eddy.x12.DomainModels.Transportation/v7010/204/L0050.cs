using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._204;

public class L0050 {
	[SectionPosition(1)] public AT5_BillOfLadingHandlingRequirements BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(2)] public RTT_FreightRateInformation? FreightRateInformation { get; set; }
	[SectionPosition(3)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
}
