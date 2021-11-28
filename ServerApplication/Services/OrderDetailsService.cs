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
    public interface IOrderDetailsService:IServiceModel<OrderDetailsModel, OrderDetail>
    {
    }
    public class OrderDetailsService: ServiceModel<OrderDetailsModel, OrderDetail>, IOrderDetailsService
    {
        public OrderDetailsService(IMapper mapper, IRepository<OrderDetail> repository) : base(mapper, repository)
        {
        }
    }
}
