using AutoMapper;
using DataShopEntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Controllers.Common;
using ServerApplication.DTO;
using ServerApplication.Models;
using ServerApplication.Services;

namespace ServerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:CrudControllerBase<CategoryDto, CategoryModel, Category>
    {
        public CategoryController(ICategoryService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
