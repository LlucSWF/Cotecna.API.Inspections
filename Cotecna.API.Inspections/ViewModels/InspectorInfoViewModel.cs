using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotecna.API.Inspections.ViewModels
{

    /// <summary>
    /// Info of an inspector
    /// </summary>
    public class InspectorInfoViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public List<InspectionViewModel> Inspections { get; set; }
    }
}
