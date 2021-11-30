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
using ServerApplication.Specifications;

namespace ServerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CrudControllerBase<OrderDto, OrderModel, Order>
    {
        protected IOrderService OrderService;
        protected IOrderDetailsService OrderDetailsService;
        public OrderController(IOrderService service, IOrderDetailsService orderDetailsService, IMapper mapper) : base(service, mapper)
        {
            OrderService = service;
            OrderDetailsService = orderDetailsService;
        }

        public override async Task<ActionResult<OrderDto>> Get(int id)
        {
            var orderResult=await base.Get(id);
            var rows = await OrderDetailsService.List(new GetOrderDetailSpecification(id));
            orderResult.Value.Details = Mapper.Map<List<OrderDetailDto>>(rows);
            return orderResult;
        }

        public override async Task<ListResult<OrderDto>> GetList(PagedSortListQuery query)
        {
             var result = await base.GetList(query);
             foreach (var orderDto in result.Result)
             {
                 orderDto.Details =
                     Mapper.Map<List<OrderDetailDto>>(
                         await OrderDetailsService.List(new GetOrderDetailSpecification(orderDto.Id)));
             }
             return result;
        }
    }
}
