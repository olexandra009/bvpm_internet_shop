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
    public interface IReviewService:IServiceModel<ReviewModel, Review>
    {
    }
    public class ReviewService: ServiceModel<ReviewModel, Review>, IReviewService
    {
        public ReviewService(IMapper mapper, IRepository<Review> repository) : base(mapper, repository)
        {
        }
    }
}
