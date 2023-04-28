using ServiceWCFLogicaCoches.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceWCFLogicaCoches.Repositorys
{
    public class RepositoryCoches
    {
        private XDocument document;

        public RepositoryCoches()
        {
            //PARA LEER RECURSOS INCRUSTADOS NECESITAMOS EL 
            //NOMBRE DE LA LIBRERIA (NAMESPACE) Y EL NOMBRE DEL FICHERO
            string resourceName = "ServiceWCFLogicaCoches.coches.xml";
            //PARA RECUPERAR UN RECURSO SE UTILIZA Stream
            Stream stream =
                this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<Coche> GetCoches()
        {
            //VAMOS A EXTRAER LOS DATOS DE CADA ELEMENT DENTRO
            //DEL DOCUMENTO XML Y CREAR LA COLECCION DIRECTAMENTE
            var consulta = from datos in this.document.Descendants("coche")
                           select new Coche
                           {
                               IdCoche = int.Parse(datos.Element("idcoche").Value),
                               Marca = datos.Element("marca").Value,
                               Modelo = datos.Element("modelo").Value,
                           };
            return consulta.ToList();
        }

        public Coche FindCoche(int idcoche)
        {
            return this.GetCoches().FirstOrDefault(x => x.IdCoche == idcoche);
        }
    }

}
