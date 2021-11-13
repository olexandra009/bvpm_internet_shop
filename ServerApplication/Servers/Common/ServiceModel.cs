using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.Servers.Common
{
    public class ServiceModel<TModel, TEntity>:IServiceModel<TModel, TEntity>
    {
        //TODO: Implement methods 
        public async Task<TModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> Create(TModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> Update(TModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TModel>> List()
        {
            throw new NotImplementedException();
        }
    }
}
