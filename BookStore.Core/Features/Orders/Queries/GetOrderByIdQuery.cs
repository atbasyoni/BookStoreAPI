using BookStore.Core.Features.Orders.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Orders;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Orders.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<OrderDTO>;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IRepository<Order> _orderRepository;

        public GetOrderByIdQueryHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var Order = await _orderRepository.GetByIdAsync(request.id);
            return Order.MapOne<OrderDTO>();
        }
    }
}
