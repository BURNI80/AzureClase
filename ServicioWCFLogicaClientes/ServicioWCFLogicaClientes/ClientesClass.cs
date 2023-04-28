using ServicioWCFLogicaClientes.Models;
using ServicioWCFLogicaClientes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWCFLogicaClientes
{
    public class ClientesClass : IClientesContract
    {
        private RepositoryClientes repo;

        public ClientesClass()
        {
            this.repo = new RepositoryClientes();
        }

        public Cliente FindCliente(int id)
        {
            return this.repo.FindCliente(id);
        }

        public List<Cliente> GetClientes()
        {
            return this.repo.GetClientes();
        }
    }
}
