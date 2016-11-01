using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Linq.Expressions;


namespace Roadmap.DAL.Core
{
    public class RoadmapRepository
    {
        protected DbContext context;
        
        public RoadmapRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return context.Set<T>();
        }

        public T Get<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return this.context.Set<T>().FirstOrDefault(condition);
        }

        public void Add<T>(T item) where T : class
        {
            this.context.Set<T>().Add(item);
        }

        public void Update<T>(T item) where T : class
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Delete<T>(T item) where T : class
        {
            this.context.Set<T>().Remove(item);
        }
    }
}