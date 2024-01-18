using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ObterProdutosMaisVendidos;

public class ObterProdutosMaisVendidosHandler(IVitrineReadOnlyRepository vitrineReadOnlyRepository)
    : IRequestHandler<ObterProdutosMaisVendidosQuery, Result<ObterProdutosMaisVendidosResult>>
{
    public async Task<Result<ObterProdutosMaisVendidosResult>> Handle(ObterProdutosMaisVendidosQuery request, CancellationToken cancellationToken)
    {
        var produtos = await vitrineReadOnlyRepository.ListarMaisVendidos(cancellationToken);
        return new ObterProdutosMaisVendidosResult(produtos);
    }
}