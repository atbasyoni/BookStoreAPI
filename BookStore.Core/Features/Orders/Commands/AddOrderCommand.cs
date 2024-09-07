using BookStore.Core.Features.Orders.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Orders;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Orders.Commands
{
    public record class AddOrderCommand(OrderCreateDTO orderCreateDTO) : IRequest<OrderDTO>;

    public record OrderAddedEvent(OrderDTO orderDTO) : INotification;

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderDTO>
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IMediator _mediator;

        public AddOrderCommandHandler(IRepository<Order> OrderRepository, IMediator mediator)
        {
            _OrderRepository = OrderRepository;
            _mediator = mediator;
        }

        public async Task<OrderDTO> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = request.orderCreateDTO.MapOne<Order>();

            Order = await _OrderRepository.AddAsync(Order);

            var OrderDTO = Order.MapOne<OrderDTO>();

            await _mediator.Publish(new OrderAddedEvent(OrderDTO));

            return OrderDTO;
        }
    }
}
