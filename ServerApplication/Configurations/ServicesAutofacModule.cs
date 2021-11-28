using Autofac;
using ServerApplication.Services;

namespace ServerApplication.Configurations
{
    public class ServicesAutofacModule : Module
    {
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
