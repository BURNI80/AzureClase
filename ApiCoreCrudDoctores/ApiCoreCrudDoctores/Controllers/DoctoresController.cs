using ApiCoreCrudDoctores.Models;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctores()
        {
            return await this.repo.GetDoctores();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDoctor(id);
        }


        [HttpDelete("{id}")]
        public async Task DeleteDoctor(int id)
        {
            await this.repo.DeleteDoctor(id);
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor(int hospitalCod, int doctorCod, string apellido, string especialidad, int salario)
        {
            return await this.repo.CreateDoctor(hospitalCod,doctorCod,apellido,especialidad,salario);
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int hospitalCod, int doctorCod, string apellido, string especialidad, int salario)
        {
            return await this.repo.UpdateDoctor(hospitalCod, doctorCod, apellido, especialidad, salario);
        }


    }
}
