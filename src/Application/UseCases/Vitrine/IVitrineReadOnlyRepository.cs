namespace ECommerce.Application.UseCases.Vitrine;

public interface IVitrineReadOnlyRepository
{
    Task<IReadOnlyCollection<Produto>> ListarMaisVendidos(CancellationToken cancellationToken = default);
}