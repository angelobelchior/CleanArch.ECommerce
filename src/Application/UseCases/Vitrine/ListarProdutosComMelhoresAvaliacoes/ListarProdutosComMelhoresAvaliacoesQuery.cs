using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ListarProdutosComMelhoresAvaliacoes;

public record ListarProdutosComMelhoresAvaliacoesQuery()
    : IRequest<Result<ListarProdutosComMelhoresAvaliacoesResult>>;
