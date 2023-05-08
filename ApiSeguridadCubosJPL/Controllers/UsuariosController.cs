using ApiSeguridadCubosJPL.Models;
using ApiSeguridadCubosJPL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

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

        //METODO PARA INSERTAR USUARIO
        [HttpPost]
        public async Task<ActionResult> InsertUsuario(Usuario user)
        {
            await this.repo.InsertUsuario(user.IdUsuario, user.Nombre, user.Email, user.Password, user.Imagen);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Usuario>> PerfilUsuario()
        {
            //DEBEMOS BUSCAR EL CLAIM DEL EMPLEADO
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario =
                claim.Value;
            Usuario user = JsonConvert.DeserializeObject<Usuario>
                (jsonUsuario);
            return user;
        }

    }
}
