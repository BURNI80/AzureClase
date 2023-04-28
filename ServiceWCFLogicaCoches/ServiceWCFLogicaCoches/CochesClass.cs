using ServiceWCFLogicaCoches.Models;
using ServiceWCFLogicaCoches.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFLogicaCoches
{
    public class CochesClass : ICochesContract
    {
        private RepositoryCoches repo;

        public CochesClass()
        {
            this.repo = new RepositoryCoches();
        }

        public Coche FindCoche(int idcoche)
        {
            return this.repo.FindCoche(idcoche);
        }

        public List<Coche> GetCoches()
        {
            return this.repo.GetCoches();
        }
    }
}
