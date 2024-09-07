using BookStore.Core.Features.Orders.DTOs;
using BookStore.Core.Helper;
using BookStore.Data.Models.Orders;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Orders.Commands
{
    public record class EditOrderCommand(OrderDTO orderDTO) : IRequest;

    public record OrderEditedEvent(OrderDTO orderDTO) : INotification;

    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMediator _mediator;

        public EditOrderCommandHandler(IRepository<Order> orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = request.orderDTO.MapOne<Order>();

            _orderRepository.Update(Order);

            await _mediator.Publish(new OrderEditedEvent(request.orderDTO));
        }
    }
}
