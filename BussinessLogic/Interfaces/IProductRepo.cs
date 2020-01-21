using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.BussinessLogic.Interfaces
{
    public interface IProductRepo<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
    }
}
