using api.Dtos.Cuentas;
using api.Dtos.Productos;
using api.Dtos.Roles;
using api.Dtos.Usuarios;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository Repo;
        private readonly ITasaCambioRepository TasaCambioRepository;

        public CuentaService(ICuentaRepository repo, ITasaCambioRepository tasaCambioRepository)
        {
            Repo = repo;
            TasaCambioRepository = tasaCambioRepository;
        }

        public async Task<Cuenta> Crear(CuentaCreacionDto cuentaCreacionDto)
        {
            Cuenta cuenta = new Cuenta
            {
                Division = cuentaCreacionDto.Division,
                Estado = cuentaCreacionDto.Estado,
                FechaCreacion = cuentaCreacionDto.FechaCreacion,
                Moneda = cuentaCreacionDto.Moneda,
                NumeroCuenta = cuentaCreacionDto.NumeroCuenta,
                Saldo = cuentaCreacionDto.Saldo
            };

            return await Repo.Crear(cuenta);
        }

        public async Task<Cuenta> Modificar(int id, CuentaModificacionDto cuentaModificacionDto)
        {
            Cuenta cuentaExistente = await Repo.ObtenerPorId(id);

            if (cuentaExistente == null)
            {
                return null;
            }

            if (cuentaModificacionDto.Division != null)
            {
                cuentaExistente.Division = cuentaModificacionDto.Division;
            }
            if (cuentaModificacionDto.Estado != null)
            {
                cuentaExistente.Estado = cuentaModificacionDto.Estado;
            }
            if (cuentaModificacionDto.FechaCreacion != null)
            {
                cuentaExistente.FechaCreacion = (DateTime)cuentaModificacionDto.FechaCreacion;
            }
            if (cuentaModificacionDto.Moneda != null)
            {
                cuentaExistente.Moneda = cuentaModificacionDto.Moneda;
            }
            if (cuentaModificacionDto.NumeroCuenta != null)
            {
                cuentaExistente.NumeroCuenta = (int)cuentaModificacionDto.NumeroCuenta;
            }
            if (cuentaModificacionDto.Saldo != null)
            {
                cuentaExistente.Saldo = (decimal)cuentaModificacionDto.Saldo;
            }

            return await Repo.Modificar(cuentaExistente);
        }

        public async Task<Cuenta> ObtenerPorId(int id)
        {
            Cuenta cuenta = await Repo.ObtenerPorId(id);

            if (cuenta == null)
            {
                return null;
            }

            return cuenta;
        }

        public async Task<List<Cuenta>> ObtenerTodas()
        {
            List<Cuenta> cuentas = await Repo.ObtenerTodas();

            foreach (Cuenta cuenta in cuentas)
            {
                if (cuenta.Moneda.Equals("USD"))
                {
                    continue;
                }

                TasasCambio tasaCambio = await TasaCambioRepository.ObtenerPorOrigen(cuenta.Moneda);
                cuenta.Saldo = cuenta.Saldo * tasaCambio.TasaCambio;
            }

            return cuentas;
        }

        public async Task<Cuenta> CambioSaldoADestino(int id, string destino)
        {
            Cuenta cuenta = await Repo.ObtenerPorId(id);
            if (cuenta == null)
            {
                return null;
            }
            TasasCambio tasaCambio = await TasaCambioRepository.ObtenerParaCambio(cuenta.Moneda, destino);
            cuenta.Saldo = cuenta.Saldo * tasaCambio.TasaCambio;
            cuenta.Moneda = destino;

            return cuenta;
        }
    }
}
