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
    public interface IReviewRepository : IRepository<Review>
    {
    }
    public class ReviewRepository:RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
