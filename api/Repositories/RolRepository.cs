using api.Models;

namespace api.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly prueba283Context Context;

        public RolRepository(prueba283Context context)
        {
            Context = context;
        }

        public async Task<Role> ObtenerPorId(int id)
        {
            return await Context.Roles.FindAsync(id);
        }
    }
}
