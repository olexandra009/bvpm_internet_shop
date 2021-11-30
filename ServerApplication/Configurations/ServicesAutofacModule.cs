using Autofac;
using ServerApplication.Services;

namespace ServerApplication.Configurations
{
    public class ServicesAutofacModule : Module
    {
        private static ServicesAutofacModule _instance;

        public static ServicesAutofacModule GetInstance()
        {
            if (_instance == null)
                _instance = new ServicesAutofacModule();
            return _instance;
        }

        private ServicesAutofacModule()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>()
                .As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsService>()
                .As<IOrderDetailsService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>()
                .As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>()
                .As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ReviewService>()
                .As<IReviewService>().InstancePerLifetimeScope();
        }
    }
}
