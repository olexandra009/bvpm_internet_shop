using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using DataShopEntityFramework.Entities;
using DataShopEntityFramework.Repositories;
using DataShopEntityFramework.Repositories.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ServerApplication.Models;
using ServerApplication.Services.Common;
using ServerApplication.Specifications;

namespace ServerApplication.Services
{
    public interface IOrderService : IServiceModel<OrderModel, Order>
    {

    }
    public class OrderService : ServiceModel<OrderModel, Order>, IOrderService
    {
        protected IOrderDetailsService OrderDetailsService;
        protected IProductService ProductService;
        public OrderService(IMapper mapper, IOrderRepository repository, IProductService productService, IOrderDetailsService orderDetailsService) : base(mapper, repository)
        {
            OrderDetailsService = orderDetailsService;
            ProductService = productService;
        }

        public override async Task<OrderModel> Get(int id)
        {
            var result = await base.Get(id);
            var details = await OrderDetailsService.List(new GetOrderDetailSpecification(result.Id));
            result.Details = details;
            return result;
        }

        public override async Task<List<OrderModel>> List()
        {
            var result = await base.List();
            foreach (var order in result)
                order.Details= await OrderDetailsService.List(new GetOrderDetailSpecification(order.Id));
            return result;
        }

        public override async Task<List<OrderModel>> List(ISpecification<Order> specification)
        {
            var result =  await base.List(specification);
            foreach (var order in result)
                order.Details = await OrderDetailsService.List(new GetOrderDetailSpecification(order.Id));
            return result;
        }

        public override async Task<OrderModel> Create(OrderModel model)
        {
            double orderCost = 0;
            foreach (var row in model.Details)
            {
                var productModel = await ProductService.Get(row.IdProduct);
                if (productModel.Amount < row.Amount)
                    row.Amount = (double) productModel.Amount;
                productModel.Amount = productModel.Amount - row.Amount;
                await ProductService.Update(productModel);
                if (productModel.Price != null)
                    orderCost += ((double) productModel.Price * row.Amount);
             
            }

            model.Cost = orderCost;
            var result = await base.Create(model);
            return result;
        }
    }
}
