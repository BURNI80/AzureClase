using ServiceWCFLogicaCoches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFLogicaCoches
{
    [ServiceContract]
    public interface ICochesContract
    {
        [OperationContract]
        List<Coche> GetCoches();

        [OperationContract]
        Coche FindCoche(int idcoche);
    }
}
