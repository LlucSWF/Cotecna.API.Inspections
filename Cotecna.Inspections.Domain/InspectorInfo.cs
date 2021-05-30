using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Domain
{
    public class InspectorInfo : EntityBase
    {
        public InspectorInfo()
        {
            Inspections = new HashSet<Inspection>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }

        public string Nif { get; set; }
        public ICollection<Inspection> Inspections { get; set; }
    }
}
