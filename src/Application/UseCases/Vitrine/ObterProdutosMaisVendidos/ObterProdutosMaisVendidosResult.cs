namespace ECommerce.Application.UseCases.Vitrine.ObterProdutosMaisVendidos;

public record ObterProdutosMaisVendidosResult(IReadOnlyCollection<Produto> Produtos);
