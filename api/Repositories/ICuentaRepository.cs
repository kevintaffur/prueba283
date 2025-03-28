using api.Models;

namespace api.Repositories
{
    public interface ICuentaRepository
    {
        Task<List<Cuenta>> ObtenerTodas();
        Task<Cuenta> ObtenerPorId(int id);
        Task<Cuenta> Crear(Cuenta cuenta);
        Task<Cuenta> Modificar(Cuenta cuenta);
    }
}
