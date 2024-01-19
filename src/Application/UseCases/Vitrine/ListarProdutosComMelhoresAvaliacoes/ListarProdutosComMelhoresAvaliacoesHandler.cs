using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ListarProdutosComMelhoresAvaliacoes;

public class ListarProdutosComMelhoresAvaliacoesHandler(IVitrineReadOnlyRepository vitrineReadOnlyRepository)
    : IRequestHandler<ListarProdutosComMelhoresAvaliacoesQuery, Result<ListarProdutosComMelhoresAvaliacoesResult>>
{
    public async Task<Result<ListarProdutosComMelhoresAvaliacoesResult>> Handle(ListarProdutosComMelhoresAvaliacoesQuery request, CancellationToken cancellationToken)
    {
        var produtos = await vitrineReadOnlyRepository.ListarProdutosMaisVendidos(cancellationToken);
        return new ListarProdutosComMelhoresAvaliacoesResult(produtos);
    }
}