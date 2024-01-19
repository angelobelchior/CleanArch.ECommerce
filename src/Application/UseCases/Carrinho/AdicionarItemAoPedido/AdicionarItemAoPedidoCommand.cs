using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Carrinho.AdicionarItemAoPedido;

public record AdicionarItemAoPedidoCommand(Guid IdDoPedido, Guid IdDoItem, int Quantidade)
    : IRequest<Result<AdicionarItemAoPedidoResult>>;