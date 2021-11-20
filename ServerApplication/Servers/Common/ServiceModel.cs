using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using ServerApplication.Specifications;
using DataShopEntityFramework.Repositories.Common;
using ServerApplication.Models;

namespace ServerApplication.Servers.Common
{
    public class ServiceModel<TModel, TEntity>:IServiceModel<TModel, TEntity>
    where TEntity: class
    where  TModel : IModel
    {
        protected IMapper Mapper;
        protected IRepository<TEntity> Repository;

        public ServiceModel(IMapper mapper, IRepository<TEntity> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public virtual async Task<TModel> Get(int id)
        {
            TEntity entity = await Repository.GetByIdAsync(id).ConfigureAwait(false);
            TModel model = Mapper.Map<TModel>(entity);
            return model;
        }

        public virtual async Task<TModel> Create(TModel model)
        {
            TEntity entity = Mapper.Map<TEntity>(model);
            TEntity resultEntity = await Repository.AddAsync(entity).ConfigureAwait(false);
            TModel resultModel = Mapper.Map<TModel>(resultEntity);
            resultModel = await Task.FromResult(resultModel).ConfigureAwait(false);
            return resultModel;
        }

        public virtual async Task<TModel> Update(TModel model)
        {
            TEntity existsEntity = await Repository.GetByIdAsync(model.Id);
            Mapper.Map(model, existsEntity);
            await Repository.UpdateAsync(existsEntity).ConfigureAwait(false);
            TModel result = Mapper.Map<TModel>(existsEntity);
            result = await Task.FromResult(result).ConfigureAwait(false);
            return result;
        }

        public async Task Delete(int id)
        {
            TEntity entity = await Repository.GetByIdAsync(id).ConfigureAwait(false);
            if (entity != null)
            {
                await Repository.DeleteAsync(entity).ConfigureAwait(false);
            }
        }

        public async Task<bool> Exist(int id)
        {
            TEntity entity = await Repository.GetByIdAsync(id);
            return (entity != null);
        }

        public virtual async Task<List<TModel>> List()
        {
            List<TEntity> entities = await Repository.ListAsync();
            List<TModel> models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        public Task<List<TModel>> List(PagedSortListQuery query)
        {
            return List(CreateSpecification(query));
        }

        public Task<int> Count(PagedSortListQuery query)
        {
            return Count(CreateSpecification(query));
        }

        public virtual async Task<List<TModel>> List(ISpecification<TEntity> specification)
        {
            List<TEntity> entities = await Repository.ListAsync(specification);
            List<TModel> models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        public virtual Task<int> Count(ISpecification<TEntity> specification)
        {
            return Repository.CountAsync(specification);
        }
        protected virtual ISpecification<TEntity> CreateSpecification(PagedSortListQuery query)
        {
            return new PagedSpecification<TEntity>(query.Take, query.Skip, query.SortProp, query.SortOrder);
        }

    }
}
