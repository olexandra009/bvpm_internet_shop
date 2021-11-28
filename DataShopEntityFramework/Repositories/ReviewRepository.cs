using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories.Common;


namespace DataShopEntityFramework.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
    }
    public class ReviewRepository:RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(ShopDBContext dbContext) : base(dbContext)
        {
        }
    }
}
