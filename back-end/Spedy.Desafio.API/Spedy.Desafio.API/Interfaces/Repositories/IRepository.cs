using Spedy.Desafio.API.Models.Entities;
using System.Collections.Generic;

namespace Spedy.Desafio.API.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Post(T entity);
        T Put(T entity);
        void Delete(int id);
        void ChangeActive(T entity);
    }
}
