using MediatR;

namespace ECommerce.Application.UseCases.Carrinho.AdicionarItemAoPedido;

public record ItemAdicionadoAoPedidoNotification(Guid IdDoPedido, Guid IdDoItem) 
    : INotification;
