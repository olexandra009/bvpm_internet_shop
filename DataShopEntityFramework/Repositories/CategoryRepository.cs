using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories.Common;

namespace DataShopEntityFramework.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
    }
    public class CategoryRepository:RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopDBContext context): base(context)
        {
            
        }
    }
}
