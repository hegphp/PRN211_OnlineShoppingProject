using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class EmployeeTerritory
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; } = null!;

        public virtual Territory Territory { get; set; } = null!;
    }
}
