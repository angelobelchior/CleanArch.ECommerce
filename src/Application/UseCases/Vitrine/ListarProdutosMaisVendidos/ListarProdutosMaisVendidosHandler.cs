using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ListarProdutosMaisVendidos;

public class ListarProdutosMaisVendidosHandler(IVitrineReadOnlyRepository vitrineReadOnlyRepository)
    : IRequestHandler<ListarProdutosMaisVendidosQuery, Result<ListarProdutosMaisVendidosResult>>
{
    public async Task<Result<ListarProdutosMaisVendidosResult>> Handle(ListarProdutosMaisVendidosQuery request, CancellationToken cancellationToken)
    {
        var produtos = await vitrineReadOnlyRepository.ListarProdutosMaisVendidos(cancellationToken);
        return new ListarProdutosMaisVendidosResult(produtos);
    }
}