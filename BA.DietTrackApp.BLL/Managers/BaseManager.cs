using BA.DietTrackApp.BLL.Services;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Anstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.BLL.Managers
{
    public class BaseManager<T> : IService<T> where T : class, IEntity
    {
        protected GenericRepository<T> _repository;
        public BaseManager(GenericRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity) => _repository.Add(entity);

        public void Delete(T entity) => _repository?.Delete(entity);

        public T? Get(int id) => _repository.Get(id);

        public List<T> GetAll() => _repository.GetAll();

        public IQueryable<T> GetQueryable() => _repository.GetQueryable();

        public void Update(T entity) => Update(entity);
    }
}
