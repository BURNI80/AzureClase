using ApiCoreHospitales.Data;
using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Repositories
{
    public class RepositoryHospitales
    {

        private ContextHospitales context; 

        public RepositoryHospitales(ContextHospitales context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitals()
        {
            return await this.context.Hospitales.ToListAsync();
        }

        public async Task<Hospital> FindHospital(int id)
        {
            return await this.context.Hospitales.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



    }
}
