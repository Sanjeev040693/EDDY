﻿using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._210
{
    
    public class StopOffDetails
    {
        [SectionPosition(1)]
        public S5_StopOffDetails Detail { get; set; }

        [SectionPosition(2)]
        public List<N9_ReferenceIdentification> ReferenceInformation{ get; set; } = new();

        [SectionPosition(3)]
        public List<G62_DateTime> Dates { get; set; } = new();

        [SectionPosition(4)]
        public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();

        [SectionPosition(5)]
        public List<OrderDetail> OrderDetail { get; set; } = new();

        [SectionPosition(6)]
        public List<PartyWithEquipmentDetails> Parties { get; set; } = new();
    }
}