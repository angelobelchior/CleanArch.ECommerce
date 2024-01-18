using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.UseCases.Vitrine.ObterProdutosMaisVendidos;

public record ObterProdutosMaisVendidosQuery(string Ordenacao) : IRequest<Result<ObterProdutosMaisVendidosResult>>;
