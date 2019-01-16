using Answer.Pos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api.Repositories
{
    public interface DataRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T document);
        void Update(T document);
        void Delete(int id);
    }
}
