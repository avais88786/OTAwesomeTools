using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenTraderSunFixes.Repository
{
    public class EFRepository<T> :IRepository<T> where T:class
    {
        protected DbContext dbContext;
        protected DbSet<T> dbSet;

        public EFRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetByReference(string reference)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
