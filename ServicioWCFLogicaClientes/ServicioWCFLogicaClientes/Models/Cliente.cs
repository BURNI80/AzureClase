using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWCFLogicaClientes.Models
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Imagen { get; set; }
    }
}
