using Microsoft.EntityFrameworkCore;
using Spedy.Desafio.API.Interfaces.Repositories;
using Spedy.Desafio.API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Spedy.Desafio.API.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<T> Get()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _dataContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public T Post(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            return entity;
        }

        public T Put(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(int id)
        {
            var obj = Get(id);

            if (obj == null)
                return;

            _dataContext.Set<T>().Remove(obj);
        }

        public void ChangeActive(T entity)
        {
            _dataContext.Entry(entity).Property(x => x.Active).IsModified = true;
        }
    }
}
