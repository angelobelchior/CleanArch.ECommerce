using ECommerce.Domain;
using ECommerce.Domain.Carrinho;

namespace ECommerce.Application.UseCases.Carrinho;

public interface IPedidoReadOnlyRepository
{
    Task<Result<Pedido>> ObterPorId(Guid id, CancellationToken cancellationToken);
}