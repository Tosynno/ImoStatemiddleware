using ImoStatemiddleware.BussinessLogic.Interfaces;
using ImoStatemiddleware.Data.ProductModel;
using ImoStatemiddleware.Utility.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.BussinessLogic.Repositories
{
    public class ProductCodeRepository : IProductRepo<ProductCode>
    {
        readonly AppDbContext db;

        public ProductCodeRepository(AppDbContext _db)
        {
            db = _db;
        }
        public ProductCode Get(long id)
        {
            return db.ProductCodes
                   .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<ProductCode> GetAll()
        {
            return db.ProductCodes.ToList();
        }
    }
}
