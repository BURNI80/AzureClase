using ReferenceClientes;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceClientes
    {
        private ClientesContractClient client;

        public ServiceClientes(ClientesContractClient client)
        {
            this.client = client;
        }

        public async Task<Cliente[]> GetClientesAsync()
        {
            return await this.client.GetClientesAsync();
        }

        public async Task<Cliente> FindClienteAsyc(int id)
        {
            return await this.client.FindClienteAsync(id);
        }
    }
}
