using Microsoft.EntityFrameworkCore;
using MvcWebJobChollometro.Data;
using MvcWebJobChollometro.Models;

namespace MvcWebJobChollometro.Repositoris
{
    public class RepositoryChollometro
    {
        private ChollometroContext context;

        public RepositoryChollometro(ChollometroContext context)
        {
            this.context = context;
        }

        public async Task<List<Chollo>> GetChollosAsync()
        {
            var consulta = from data in this.context.Chollos
                           orderby data.Fecha descending
                           select data;
            return await consulta.ToListAsync();
        }



    }
}
