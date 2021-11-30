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
    public interface IOrderDetailsService:IServiceModel<OrderDetailsModel, OrderDetail>
    {
    }
    public class OrderDetailsService: ServiceModel<OrderDetailsModel, OrderDetail>, IOrderDetailsService
    {
        protected IProductService ProductService;
        protected IOrderService OrderService;
        public OrderDetailsService(IMapper mapper, IOrderService orderService, IProductService productService, IOrderDetailRepository repository) : base(mapper, repository)
        {
            ProductService = productService;
            OrderService = orderService;
        }

        public override async Task Delete(int id)
        {
            var row = await Get(id);
            var product = await ProductService.Get(row.IdProduct);
            var order = await OrderService.Get(row.IdOrder);
            product.Amount += row.Amount;
            if (product.Price != null) 
                order.Cost -= row.Amount * (double) product.Price;
            await ProductService.Update(product);
            await OrderService.Update(order);
            await base.Delete(id);
        }

        public override async Task<OrderDetailsModel> Update(OrderDetailsModel model)
        {
         
            var row = await Get(model.Id);
            var d = row.Amount - model.Amount;
            var product = await ProductService.Get(row.IdProduct);
            var order = await OrderService.Get(row.IdOrder);
            product.Amount += d;
            if (product.Price != null) 
                order.Cost -= d * (double) product.Price;
            await ProductService.Update(product);
            await OrderService.Update(order);
            return await base.Update(model);
        }
    }
}
