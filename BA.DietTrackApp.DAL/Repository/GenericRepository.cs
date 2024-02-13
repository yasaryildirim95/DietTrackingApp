using BA.DietTrackApp.DAL.Abstract;
using BA.DietTrackApp.Entity.Anstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.DietTrackApp.DAL.Repository
{
    
        public class GenericRepository<T> : IRepository<T> where T : class, IEntity
        {
            private DbContext DbContext { get; set; }
            protected DbSet<T> _dbset;
            public GenericRepository(DbContext context)
            {
                DbContext = context;
                _dbset = DbContext.Set<T>();

            }
            public void Add(T entity)
            {
                _dbset.Add(entity);
                DbContext.SaveChanges();
            }
            public void Delete(T entity)
            {
                _dbset.Remove(entity);
                DbContext.SaveChanges();
            }
            public T? Get(int id) => _dbset.Where(x => x.Id == id).FirstOrDefault();
            public List<T> GetAll() => _dbset.ToList();
          
            public void Update(T entity)
            {
                var oldDAta = _dbset.Find(entity.Id);

                oldDAta = entity;
                DbContext.SaveChanges();
            }
            public IQueryable<T> GetQueryable() => _dbset.AsQueryable<T>();




        }
    }

