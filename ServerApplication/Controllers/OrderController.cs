using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using Microsoft.AspNetCore.Http;
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
    public class OrderController : CrudControllerBase<OrderDto, OrderModel, Order>
    {
        protected IOrderService OrderService;
        public OrderController(IOrderService service, IMapper mapper) : base(service, mapper)
        {
            OrderService = service;
        }
        
    }
}
