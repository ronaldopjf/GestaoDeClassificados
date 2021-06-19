using Microsoft.EntityFrameworkCore;
using Spedy.Desafio.API.Interfaces.Repositories;
using Spedy.Desafio.API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Spedy.Desafio.API.Infrastructure.Data.Repositories
{
    public class ClassifiedRepository : Repository<Classified>, IClassifiedRepository
    {
        public ClassifiedRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Classified> Get(string title)
        {
            return _dataContext.Set<Classified>().Where(c => c.Title == title).AsNoTracking();
        }
    }
}
