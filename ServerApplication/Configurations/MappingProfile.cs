using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataShopEntityFramework.Entities;
using ServerApplication.DTO;
using ServerApplication.Models;

namespace ServerApplication.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            CreateMap<CategoryModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryModel>();

            CreateMap<OrderDetail, OrderDetailsModel>();
            CreateMap<OrderDetailsModel, OrderDetail>();
            CreateMap<OrderDetailsModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailsModel>();

            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>();
            CreateMap<OrderModel, OrderDto>();
            CreateMap<OrderDto, OrderModel>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();

            CreateMap<Review, ReviewModel>();
            CreateMap<ReviewModel, Review>();
            CreateMap<ReviewModel, ReviewDto>();
            CreateMap<ReviewDto, ReviewModel>();

        }
    }
}
