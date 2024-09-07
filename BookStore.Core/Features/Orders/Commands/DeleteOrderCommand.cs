using BookStore.Data.Models.Orders;
using BookStore.Infrastructure.Repositories;
using MediatR;

namespace BookStore.Core.Features.Orders.Commands
{
    public record class DeleteOrderCommand(int id) : IRequest;

    public record OrderDeletedEvent(int id) : INotification;

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMediator _mediator;

        public DeleteOrderCommandHandler(IRepository<Order> orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            _orderRepository.Delete(request.id);

            await _mediator.Publish(new OrderDeletedEvent(request.id));
        }
    }
}
