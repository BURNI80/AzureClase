using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDoctores.Models;
using MvcCoreApiCrudDoctores.Services;

namespace MvcCoreApiCrudDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        private ServiceApiDoctores service;

        public DoctoresController(ServiceApiDoctores service)
        {
            this.service = service;
        }

        public async Task< IActionResult> Doctores()
        {
            List<Doctor> doctores = await this.service.GetDoctoresAsync();
            return View(doctores);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteDoctor(id);
            return RedirectToAction("Doctores");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int docNo, int hospCod, string apellido, string especialidad, int salario)
        {
            await this.service.InsertDoctorAsync(hospCod, docNo, apellido, especialidad, salario);
            return RedirectToAction("Doctores");
        }
    }
}
