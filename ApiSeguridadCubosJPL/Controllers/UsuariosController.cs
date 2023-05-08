using ApiSeguridadCubosJPL.Models;
using ApiSeguridadCubosJPL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeguridadCubosJPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private RepositoryCubos repo;

        public UsuariosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> FindUsuario(int id)
        {
            return await this.repo.FindUsuario(id);
        }

        //METODO PARA INSERTAR CUBO
        [HttpPost]
        public async Task<ActionResult> InsertUsuario(Usuario user)
        {
            await this.repo.InsertUsuario(user.IdUsuario, user.Nombre, user.Email, user.Password, user.Imagen);
            return Ok();
        }
    }
}
