using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UnitedReporting.Model;

namespace UnitedReporting.DataAccess
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new UnitedReportingContainer())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList();
            }
            return list;
        }

        public IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new UnitedReportingContainer())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList();
            }
            return list;
        }

        public T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item;
            using (var context = new UnitedReportingContainer())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);
                
                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public void Add(params T[] items)
        {
            using (var context = new UnitedReportingContainer())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Added;
                    context.Set<T>().Add(item);
                }
                context.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            using (var context = new UnitedReportingContainer())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void Remove(params T[] items)
        {
            using (var context = new UnitedReportingContainer())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}

