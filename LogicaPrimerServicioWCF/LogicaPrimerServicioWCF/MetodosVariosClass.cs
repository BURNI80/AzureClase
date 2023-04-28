using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaPrimerServicioWCF
{
    public class MetodosVariosClass : IMetodosVariosContract
    {
        public int GetNumeroDoble(int numero)
        {
            return numero * 2;
        }

        public string GetSaludo(string nombre)
        {
            return "Mi primer super Servicio!!!, " + nombre;
        }

        public string MetodoInvisible()
        {
            return "No sirvo para nada, soy invisible";
        }

        public List<int> GetTablaMultiplicar(int num)
        {
            List<int> list = new List<int>();
            for(int i = 0; i< 10; i++)
            {
                list.Add(i*num);
            }
            return list;
        }
    }
}
