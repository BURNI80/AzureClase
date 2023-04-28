using ServicioWCFLogicaClientes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServicioWCFLogicaClientes.Repository
{
    public class RepositoryClientes : IClientesContract
    {
        private XDocument document;

        public RepositoryClientes()
        {
            string resourceName = "ServicioWCFLogicaClientes.clientes.xml";
            Stream stream =
                this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<Cliente> GetClientes()
        {
            var consulta = from datos in this.document.Descendants("CLIENTE")
                           select new Cliente
                           {
                               Id = int.Parse(datos.Element("IDCLIENTE").Value),
                               Nombre = datos.Element("NOMBRE").Value,
                               Direccion = datos.Element("DIRECCION").Value,
                               Email = datos.Element("EMAIL").Value,
                               Imagen = datos.Element("IMAGENCLIENTE").Value,

                           };
            return consulta.ToList();
        }

        public Cliente FindCliente(int id)
        {
            return GetClientes().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
