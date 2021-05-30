using Cotecna.Inspections.Data.Repositories.Investel.CustomerSite.Data.Repositories;
using Cotecna.Inspections.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cotecna.Inspections.Data.Repositories
{
    public interface IInspectionRepository : IRepository<Inspection>
    {
        List<Inspection> getWithInspectorIdAndDate(int inspectorId, DateTime date);
    }

    public class InspectionRepository : Repository<Inspection>, IInspectionRepository
    {

        public InspectionRepository(InspectionsContext context) : base(context)
        {
            Context = context;
        }

        public List<Inspection> getWithInspectorIdAndDate(int inspectorId, DateTime date)
        {
            return EntitySet.Where(i => i.InspectorId == inspectorId && i.ScheduledDate.Day == date.Day
                                                               && i.ScheduledDate.Month == date.Month
                                                               && i.ScheduledDate.Year == date.Year && !i.Cancelled).ToList();
        }

    }
}
