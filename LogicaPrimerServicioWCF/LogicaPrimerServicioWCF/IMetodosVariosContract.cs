using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LogicaPrimerServicioWCF
{
    [ServiceContract]
    public interface IMetodosVariosContract
    {
        [OperationContract]
        int GetNumeroDoble(int numero);
        [OperationContract]
        string GetSaludo(string nombre);
        string MetodoInvisible();
    }
}
