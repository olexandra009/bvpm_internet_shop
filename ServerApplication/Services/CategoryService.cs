using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories;
using DataShopEntityFramework.Repositories.Common;
using ServerApplication.Models;
using ServerApplication.Services.Common;

namespace ServerApplication.Services
{
    public interface ICategoryService:IServiceModel<CategoryModel, Category>
    {
    }
    public class CategoryService:ServiceModel<CategoryModel, Category>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepository repository) : base(mapper, repository)
        {
        }
    }
}
