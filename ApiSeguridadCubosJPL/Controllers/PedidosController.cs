using ApiSeguridadCubosJPL.Models;
using ApiSeguridadCubosJPL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeguridadCubosJPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private RepositoryCubos repo;

        public PedidosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
        [Authorize]
        //Funcion para sacar mostrar los pedidos
        public async Task<ActionResult<List<CompraCubo>>> GetPedidos(int id)
        {
            return await this.repo.GetPedidosAsync(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> InsertPedido(CompraCubo compra)
        {
            await this.repo.InsertPedido(compra.IdPedido, compra.IdCubo, compra.IdUsuario, compra.FechaPedido);
            return Ok();
        }

    }
}
