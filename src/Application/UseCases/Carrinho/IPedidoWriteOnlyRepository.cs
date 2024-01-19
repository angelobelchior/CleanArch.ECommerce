using ECommerce.Domain;
using ECommerce.Domain.Carrinho;

namespace ECommerce.Application.UseCases.Carrinho;

public interface IPedidoWriteOnlyRepository
{
    Task<Result> AtualizaPedido(Pedido pedido, CancellationToken cancellationToken);
}