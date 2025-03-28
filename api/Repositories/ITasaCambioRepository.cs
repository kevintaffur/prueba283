using api.Models;

namespace api.Repositories
{
    public interface ITasaCambioRepository
    {
        Task<List<TasasCambio>> ObtenerTodas();
        Task<TasasCambio> ObtenerPorOrigen(string origen);
        Task<TasasCambio> Crear(TasasCambio tc);
        Task<TasasCambio> Modificar(TasasCambio tc);
        Task<TasasCambio> ObtenerParaCambio(string origen, string destino);
    }
}
