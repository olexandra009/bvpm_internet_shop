using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Models;
using ServerApplication.Servers.Common;

namespace ServerApplication.Controllers.Common
{
    public class CrudControllerBase <TDto, TModel, TEntity>: ControllerBase
        where TModel: IModel
        where TEntity: class
    {
        //TODO: Add mapper
        //TODO: Implement methods
        //TODO: Paging? and list result 
        protected readonly IServiceModel<TModel, TEntity> Service;

        public CrudControllerBase(IServiceModel<TModel, TEntity> service)
        {
            Service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Update(int id, [FromBody] TDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<TDto> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
