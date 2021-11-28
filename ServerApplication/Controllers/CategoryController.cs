using AutoMapper;
using DataShopEntityFramework.Entities;
using ServerApplication.Controllers.Common;
using ServerApplication.DTO;
using ServerApplication.Models;
using ServerApplication.Services;

namespace ServerApplication.Controllers
{
    public class CategoryController:CrudControllerBase<CategoryDto, CategoryModel, Category>
    {
        public CategoryController(ICategoryService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
