using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Models;
using MvcCoreClienteWCF.Services;

namespace MvcCoreClienteWCF.Controllers
{
    public class CatastroController : Controller
    {
        private ServiceCatastro service;

        public CatastroController(ServiceCatastro service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Provincia> provincias = await this.service.GetProvinciasAsync();
            return View(provincias);
        }

        public async Task<IActionResult> Municipios(string provincia)
        {
            List<string> municipios = await this.service.GetMunicipiosAsync(provincia);
            return View(municipios);
        }
    }
}
