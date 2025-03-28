using api.Dtos.Cuentas;
using api.Dtos.Productos;
using api.Models;

namespace api.Services
{
    public interface ICuentaService
    {
        Task<List<Cuenta>> ObtenerTodas();
        Task<Cuenta> ObtenerPorId(int id);
        Task<Cuenta> Crear(CuentaCreacionDto cuentaCreacionDto);
        Task<Cuenta> Modificar(int id, CuentaModificacionDto cuentaModificacionDto);
        Task<Cuenta> CambioSaldoADestino(int id, string destino);
        Task<decimal> CalculoInteres(int id, int dias);
    }
}
