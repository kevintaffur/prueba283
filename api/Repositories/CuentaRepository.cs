using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly prueba283Context Context;

        public CuentaRepository(prueba283Context context)
        {
            Context = context;
        }

        public async Task<Cuenta> Crear(Cuenta cuenta)
        {
            await Context.Cuentas.AddAsync(cuenta);
            await Context.SaveChangesAsync();

            return cuenta;
        }

        public async Task<Cuenta> Modificar(Cuenta cuenta)
        {
            Context.Entry(cuenta).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return cuenta;
        }

        public async Task<Cuenta> ObtenerPorId(int id)
        {
            return await Context.Cuentas.Where(p => !p.Estado.Equals("N")).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Cuenta>> ObtenerTodas()
        {
            return await Context.Cuentas.Where(p => !p.Estado.Equals("N")).ToListAsync();
        }
    }
}
