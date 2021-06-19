using Spedy.Desafio.API.Models.Entities;
using System.Collections.Generic;

namespace Spedy.Desafio.API.Interfaces.Repositories
{
    public interface IClassifiedRepository : IRepository<Classified>
    {
        IEnumerable<Classified> Get(string title);
    }
}
