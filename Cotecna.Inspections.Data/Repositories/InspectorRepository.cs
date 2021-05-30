using Cotecna.Inspections.Data.Repositories.Investel.CustomerSite.Data.Repositories;
using Cotecna.Inspections.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cotecna.Inspections.Data.Repositories
{
    public interface IInspectorRepository : IRepository<InspectorInfo>
    {

        public List<InspectorInfo> getAvailableOnDate(DateTime date);
    }

    public class InspectorRepository : Repository<InspectorInfo>, IInspectorRepository
    {

        public InspectorRepository(InspectionsContext context) : base(context)
        {
            Context = context;
        }

        public List<InspectorInfo> getAvailableOnDate(DateTime date)
        {
            return EntitySet.Where(i => !i.Inspections.Any(x => x.ScheduledDate.Day == date.Day 
                                                               && x.ScheduledDate.Month == date.Month
                                                               && x.ScheduledDate.Year == date.Year && !x.Cancelled)).ToList();
        }

    }
}
