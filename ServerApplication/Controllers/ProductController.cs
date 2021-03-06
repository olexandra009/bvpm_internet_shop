using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Controllers.Common;
using ServerApplication.DTO;
using ServerApplication.Models;
using ServerApplication.Services;
using ServerApplication.Services.Common;

namespace ServerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:CrudControllerBase<ProductDto, ProductModel, Product>
    {
        public ProductController(IProductService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
