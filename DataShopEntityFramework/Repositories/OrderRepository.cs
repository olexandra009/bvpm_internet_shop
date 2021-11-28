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
    public interface IOrderRepository : IRepository<Order>
    {
    }
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ShopDBContext dbContext) : base(dbContext)
        {
        }
    }
}
