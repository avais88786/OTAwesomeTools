using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Repository
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetByReference(string reference);

    }
}
