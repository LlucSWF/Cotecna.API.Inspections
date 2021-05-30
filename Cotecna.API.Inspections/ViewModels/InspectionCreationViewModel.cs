using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotecna.API.Inspections.ViewModels
{

    /// <summary>
    /// Necessary info to create an Inspection.
    /// </summary>
    public class InspectionCreationViewModel
    {
        public DateTime ScheduledDate { get; set; }
        public string Address { get; set; }
        public int InspectorId { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}
