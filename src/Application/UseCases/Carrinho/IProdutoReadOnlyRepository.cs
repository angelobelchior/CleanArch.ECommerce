using ECommerce.Application.UseCases.Vitrine;
using ECommerce.Domain;

namespace ECommerce.Application.UseCases.Carrinho;

public interface IProdutoReadOnlyRepository
{
    Task<Result<Produto>> ObterPorId(Guid id, CancellationToken cancellationToken);
}