using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using ServerApplication.Controllers.Common;
using ServerApplication.DTO;
using ServerApplication.Models;
using ServerApplication.Services;
using ServerApplication.Services.Common;

namespace ServerApplication.Controllers
{
    public class OrderController : CrudControllerBase<OrderDto, OrderModel, Order>
    {
        public OrderController(IOrderService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
