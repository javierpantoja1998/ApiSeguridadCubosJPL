using ApiSeguridadCubosJPL.Models;
using ApiSeguridadCubosJPL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeguridadCubosJPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        //METODO PARA SACAR TODOS LOS CUBOS
        [HttpGet]
        
        public async Task<ActionResult<List<Cubo>>> GetCubos()
        {
            return await this.repo.GetCubosAsync();
        }

        //METODO PARA BUSCAR CUBO
        [HttpGet("{marca}")]
        public async Task <ActionResult<List<Cubo>>> FindCubo(string marca)
        {
            return await this.repo.FindCuboAsync(marca);
        }

        //METODO PARA INSERTAR CUBO
        [HttpPost]
        public async Task<ActionResult> InsertCubo(Cubo cubo)
        {
            await this.repo.InsertCubo(cubo.IdCubo, cubo.Nombre,
                cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }
    }
}
