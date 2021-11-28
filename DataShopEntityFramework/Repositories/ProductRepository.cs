using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace DataShopEntityFramework.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
    }
    public class ProductRepository:RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopDBContext dbContext) : base(dbContext)
        {
        }
    }
}
