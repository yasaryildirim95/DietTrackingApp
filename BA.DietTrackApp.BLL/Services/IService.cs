using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.BLL.Services
{
    public interface IService<T> where T : class, IEntity
    {
        T? Get(int id);
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetQueryable();

    }
}
