using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Models;
using ServerApplication.Servers.Common;
using ServerApplication.Specifications;

namespace ServerApplication.Controllers.Common
{
    public class CrudControllerBase <TDto, TModel, TEntity>: ControllerBase
        where TModel: IModel
        where TEntity: class
    {
        
        protected readonly IServiceModel<TModel, TEntity> Service;
        protected readonly IMapper Mapper;

        public CrudControllerBase(IServiceModel<TModel, TEntity> service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Get(int id)
        {
            var model = await Service.Get(id);
            if (model == null)
                return NotFound();
            var result = Mapper.Map<TDto>(model);
            return result;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Update(int id, [FromBody] TDto dto)
        {
            var exist = await Service.Get(id);
            if (exist == null)
                return NotFound();
            var model = Mapper.Map<TModel>(dto);
            model.Id = id;
            var update = await Service.Update(model);
            var result = Mapper.Map<TDto>(update);
            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
        {
            var model = Mapper.Map<TModel>(dto);
            if (!(model.Id.Equals(default(int)))) throw new ArgumentException();
            var createdModel = await Service.Create(model);
            var result = Mapper.Map<TDto>(createdModel);
            return Created("", result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<ActionResult> Delete(int id)
        {
            if (await Service.Exist(id))
                await Service.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ListResult<TDto>> GetList([FromQuery] PagedSortListQuery query)
        {
            var model = await Service.List(query);
            ListResult<TDto> result = new ListResult<TDto>
            {
                Result = Mapper.Map<List<TDto>>(model),
                Total = await Service.Count(query.TakeAll())
            };
            return result;
        }
    }
}
