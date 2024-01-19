using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ListarProdutosMaisVendidos;

public record ListarProdutosMaisVendidosQuery(string Ordenacao)
    : IRequest<Result<ListarProdutosMaisVendidosResult>>
{

}
