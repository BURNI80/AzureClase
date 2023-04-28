using ReferenceMetodosVarios;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceMetodosVarios
    {
        MetodosVariosContractClient client;

        public ServiceMetodosVarios(MetodosVariosContractClient client)
        {
            this.client = client;
        }

        public async Task<int[]> GetTablaMultiplicar(int numero)
        {
            int[] results = 
                await this.client.GetTablaMultiplicarAsync(numero);
            return results;
        }
    }
}
