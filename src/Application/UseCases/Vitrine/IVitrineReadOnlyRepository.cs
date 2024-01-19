namespace ECommerce.Application.UseCases.Vitrine;

public interface IVitrineReadOnlyRepository
{
    Task<IReadOnlyCollection<Produto>> ListarProdutosMaisVendidos(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Produto>> ListarProdutosComMelhoresAvaliacoes(CancellationToken cancellationToken = default);}