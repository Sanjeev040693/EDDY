﻿using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._8020._210;

public class EquipmentDetails
{
    [SectionPosition(1)]
    public N7_EquipmentDetails Detail { get; set; }
    
    [SectionPosition(5)]
    public List<M7_SealNumbers> SealNumbers { get; set; } = new();
}