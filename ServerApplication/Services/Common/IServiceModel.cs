using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using ServerApplication.Specifications;

namespace ServerApplication.Services.Common
{
    public interface IServiceModel<TModel, TEntity>
    {
        Task<TModel> Get(int id);
        Task<TModel> Create(TModel model);
        Task<TModel> Update(TModel model);
        Task Delete(int id);
        Task<bool> Exist(int id);
        Task<List<TModel>> List();
        Task<List<TModel>> List(PagedSortListQuery query);
        Task<int> Count(PagedSortListQuery query);
        Task<List<TModel>> List(ISpecification<TEntity> specification);
        Task<int> Count(ISpecification<TEntity> specification);

    }
}
