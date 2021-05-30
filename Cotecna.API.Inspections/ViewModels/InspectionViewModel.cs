using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotecna.API.Inspections.ViewModels
{
    /// <summary>
    /// Info about an inspection
    /// </summary>
    public class InspectionViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Address { get; set; }
        public decimal? Rating { get; set; }
    }
}
