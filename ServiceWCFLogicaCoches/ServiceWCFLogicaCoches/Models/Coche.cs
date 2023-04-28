using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFLogicaCoches.Models
{
    [DataContract]
    public class Coche
    {
        [DataMember]
        public int IdCoche { get; set; }
        [DataMember]
        public string Marca { get; set; }
        [DataMember]
        public string Modelo { get; set; }
    }
}
