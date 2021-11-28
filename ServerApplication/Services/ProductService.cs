using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories.Common;
using ServerApplication.Models;
using ServerApplication.Services.Common;

namespace ServerApplication.Services
{
    public interface IProductService:IServiceModel<ProductModel, Product>
    {
    }
    public class ProductService:ServiceModel<ProductModel, Product>, IProductService
    {
        public ProductService(IMapper mapper, IRepository<Product> repository) : base(mapper, repository)
        {
        }
    }
}
