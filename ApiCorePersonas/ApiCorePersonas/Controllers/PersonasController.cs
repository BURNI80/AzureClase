using ApiCorePersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCorePersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public List<Persona> personas;

        public PersonasController()
        {
            this.personas = new List<Persona>
            {
                new Persona {IdPersona = 1, Nombre="Sergio" ,Edad=14, Email="tinder@gmail.com"},
                new Persona {IdPersona = 2, Nombre="Alvaro", Edad=21 , Email ="alvaro@gmail.com"},
                new Persona{IdPersona = 3, Nombre = "JC" , Edad =22 , Email= "quiromitesla@gmail.com"},
                new Persona{IdPersona = 4, Nombre = "Felix" , Edad =44 , Email= "mehefolladoamiprima@gmail.com"}
            };
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return this.personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> FindPersona(int id)
        {
            return this.personas.Where( x=> x.IdPersona == id).FirstOrDefault();
        }
    }
}
