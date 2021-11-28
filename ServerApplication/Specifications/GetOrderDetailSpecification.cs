using Ardalis.Specification;
using DataShopEntityFramework.Entities;

namespace ServerApplication.Specifications
{
    public class GetOrderDetailSpecification : Specification<OrderDetail>
    {
        public GetOrderDetailSpecification(int orderId)
        {
            Query.Where(p => p.IdOrder == orderId);
        }
    }
}
