using Cotecna.Inspections.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cotecna.Inspections.Data.Repositories
{
    namespace Investel.CustomerSite.Data.Repositories
    {
        public interface IRepository<T> where T : EntityBase
        {
            T GetById(object id);

            List<T> GetAll();

            T Create(T entity);

            void Delete(T entity);

            void Delete(object Id);

            T Update(T entity);

            IEnumerable<T> UpdateRange(IEnumerable<T> entities);

            void SaveChanges();

            void UpdateField(object id, string propertyName, object propertyValue);

            IEnumerable<T> CreateRange(IEnumerable<T> entities);
        }

        public class Repository<T> : IRepository<T> where T : EntityBase
        {
            protected InspectionsContext Context { get; set; }
            protected DbSet<T> EntitySet { get; set; }

            public Repository(InspectionsContext context)
            {
                Context = context;
                EntitySet = Context.Set<T>();
            }

            public T Create(T entity)
            {
                EntitySet.Add(entity);
                Context.SaveChanges();
                return entity;
            }

            public void Delete(T entity)
            {
                EntitySet.Remove(entity);
                Context.SaveChanges();
            }

            public void Delete(object id)
            {
                EntitySet.Remove(EntitySet.Find(id));
                Context.SaveChanges();
            }

            public T GetById(object id)
            {
                return EntitySet.Find(id);
            }

            public T Update(T entity)
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }


            public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
            {
                Context.UpdateRange(entities);
                SaveChanges();
                return entities;
            }

            public List<T> GetAll()
            {
                return EntitySet.ToList();
            }

            public void SaveChanges()
            {
                Context.SaveChanges();
            }

            public void UpdateField(object id, string propertyName, object propertyValue)
            {
                var entity = EntitySet.Find(id);
                Context.Entry(entity).Property(propertyName).CurrentValue = propertyValue;
                Context.SaveChanges();
            }

            public IEnumerable<T> CreateRange(IEnumerable<T> entities)
            {
                EntitySet.AddRange(entities);
                Context.SaveChanges();
                return entities;
            }


        }

    }
}
