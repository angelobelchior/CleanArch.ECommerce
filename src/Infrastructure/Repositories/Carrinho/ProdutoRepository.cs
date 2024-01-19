using ECommerce.Application.UseCases.Carrinho;
using ECommerce.Application.UseCases.Vitrine;
using ECommerce.Domain;

namespace ECommerce.Infrastructure.Repositories.Carrinho;

internal class ProdutoRepository : IProdutoReadOnlyRepository
{
    public Task<Result<Produto>> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Produto>.Success(new Produto(id, "Produto 1", 50)));
    }
}