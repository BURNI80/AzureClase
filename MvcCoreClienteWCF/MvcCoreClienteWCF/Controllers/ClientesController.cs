using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;

namespace MvcCoreClienteWCF.Controllers
{
    public class ClientesController : Controller
    {
        private ServiceClientes service;

        public ClientesController(ServiceClientes service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.service.GetClientesAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.service.FindClienteAsyc(id));
        }
    }
}
