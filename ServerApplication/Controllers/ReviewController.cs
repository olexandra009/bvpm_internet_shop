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
    public class ReviewController: CrudControllerBase<ReviewDto, ReviewModel, Review>
    {
        public ReviewController(IReviewService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
