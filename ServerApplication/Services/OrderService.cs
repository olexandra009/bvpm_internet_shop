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
    public interface IOrderService : IServiceModel<OrderModel, Order>
    {
    }
    public class OrderService : ServiceModel<OrderModel, Order>, IOrderService
    {
        public OrderService(IMapper mapper, IRepository<Order> repository) : base(mapper, repository)
        {
        }
    }
}
