using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataShopEntityFramework.Repositories;

namespace ServerApplication.Configurations
{
    public class RepositoryAutofacModule : Module
    {
        private static RepositoryAutofacModule _instance;

        public static RepositoryAutofacModule GetInstance()
        {
            if (_instance == null)
                _instance = new RepositoryAutofacModule();
            return _instance;
        }
        private RepositoryAutofacModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>().InstancePerLifetimeScope();
           
            builder.RegisterType<OrderDetailRepository>()
                .As<IOrderDetailRepository>().InstancePerLifetimeScope();
            
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>().InstancePerLifetimeScope();
            
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>().InstancePerLifetimeScope();
            
            builder.RegisterType<ReviewRepository>()
                .As<IReviewRepository>().InstancePerLifetimeScope();
        }
    }
}
