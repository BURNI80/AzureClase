using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WebJobChollometro.Data;
using WebJobChollometro.Models;

namespace WebJobChollometro.Repositories
{
    public class RepositoryChollo
    {
        private ChollometroContext context;

        public RepositoryChollo(ChollometroContext context)
        {
            this.context = context;
        }

        private int GetMaxId()
        {
            if (this.context.Chollos.Count() != 0)
            {
                return this.context.Chollos.Max(x => x.IdChollo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private async Task<List<Chollo>> GetChollosWebAsync()
        {
            string url = "https://www.chollometro.com/rss";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = @"text/html application/xhtml+xml, *.*";
            request.Referer = "http://www.chollometro.com/";
            request.Headers.Add("Accept-Lenguage", "es-ES");
            request.Host = "www.chollometro.com";
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string xmldata = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                xmldata = await reader.ReadToEndAsync();
            }
            XDocument document = XDocument.Parse(xmldata);

            var consulta = from data in document.Descendants("item")
                           select data;

            List<Chollo> chollos = new List<Chollo>();
            int idChollo = this.GetMaxId();

            foreach (XElement tag in consulta)
            {
                Chollo c = new Chollo();
                c.IdChollo = idChollo;
                c.Titulo = tag.Element("title").Value;
                c.Descripcion = tag.Element("description").Value;
                c.Link = tag.Element("link").Value;
                c.Fecha = DateTime.Now;
                idChollo += 1;
                chollos.Add(c);
            }

            return chollos;
        }

        public async Task PopularChollosAsync()
        {
            List<Chollo> chollos = await this.GetChollosWebAsync();
            foreach(Chollo c in chollos)
            {
                this.context.Chollos.Add(c);
            }
            await this.context.SaveChangesAsync();
        }


    }
}
