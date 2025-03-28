using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TasaCambioRepository : ITasaCambioRepository
    {
        private readonly prueba283Context Context;

        public TasaCambioRepository(prueba283Context context)
        {
            Context = context;
        }

        public async Task<TasasCambio> Crear(TasasCambio tc)
        {
            await Context.TasasCambios.AddAsync(tc);
            await Context.SaveChangesAsync();

            return tc;
        }

        public async Task<TasasCambio> Modificar(TasasCambio tc)
        {
            Context.Entry(tc).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return tc;
        }

        public async Task<TasasCambio> ObtenerPorOrigen(string origen)
        {
            return await Context.TasasCambios.Where(tc => !tc.Estado.Equals("N") && tc.MonedaOrigen.ToUpper().Equals(origen.ToUpper()) && tc.MonedaDestino.Equals("USD")).FirstOrDefaultAsync();
        }
        public async Task<TasasCambio> ObtenerParaCambio(string origen, string destino)
        {
            return await Context.TasasCambios.Where(tc => !tc.Estado.Equals("N") && tc.MonedaOrigen.ToUpper().Equals(origen.ToUpper()) && tc.MonedaDestino.ToUpper().Equals(destino.ToUpper())).FirstOrDefaultAsync();
        }

        public async Task<List<TasasCambio>> ObtenerTodas()
        {
            return await Context.TasasCambios.Where(tc => !tc.Estado.Equals("N")).ToListAsync();
        }
    }
}
