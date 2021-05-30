using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Domain
{
    public class Inspection : EntityBase
    {
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Address { get; set; }
        public decimal? Rating { get; set; }
        public int InspectorId { get; set; }

        public bool Cancelled { get; set; }
        public InspectorInfo Inspector { get; set; }
    }
}
 