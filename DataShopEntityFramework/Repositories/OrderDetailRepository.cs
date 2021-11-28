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
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }
    public class OrderDetailRepository: RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
