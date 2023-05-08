using ApiSeguridadCubosJPL.Data;
using ApiSeguridadCubosJPL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridadCubosJPL.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        //IMPLEMENTACION DE SEGURIDAD EN LA API

        //METODO PARA VER SI EXISTE EL USUARIO
        public async Task<Usuario> ExisteUsuarioAsync
            (string email, string password)
        {
            return await
                this.context.Usuarios.FirstOrDefaultAsync
                (z => z.Email == email
                && z.Password == password);
        }

        //METODOS PARA LOS CUBOS

        //METODO PARA SACAR TODOS LOS CUBOS
        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await
                this.context.Cubos.ToListAsync();
        }

        //METODO PARA BUSCAR CUBO
        public async Task<List<Cubo>> FindCuboAsync(string marca)
        {
            return await
                this.context.Cubos.ToListAsync
                ();
        }
        //METODO PARA INSERTAR CUBO
        //Funcion para insertar
        public async Task InsertCubo
            (int idcubo, string nombre,string marca,
            string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.IdCubo = idcubo;
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
        }

        //FUNCION PARA MOSTRAR DETALLES USUARIO
        public async Task<Usuario> FindUsuario(int id)
        {
            return await
                this.context.Usuarios.FirstOrDefaultAsync
                (x => x.IdUsuario == id);
        }

        
        //FUNCION PARA INSERTAR UN USUARIO
        public async Task InsertUsuario
           (int id, string nombre, string email, string password, string imagen)
        {
            Usuario user = new Usuario();
            user.IdUsuario = id;
            user.Nombre = nombre;
            user.Email = email;
            user.Password = password;
            user.Imagen = imagen;
            
            this.context.Usuarios.Add(user);
            await this.context.SaveChangesAsync();
        }

        //FUNCION PARA MOSTRAR PEDIDOS
        public async Task<List<CompraCubo>> GetPedidosAsync(int id)
        {
            return await
                this.context.Pedidos.Where
                (x => x.IdUsuario == id).ToListAsync();
        }

        //FUNCION PARA REALIZAR UNA COMPRA
        public async Task InsertPedido
           (int idpedido, int idcubo, int idusuario, DateTime fecha)
        {
            CompraCubo compra = new CompraCubo();
            compra.IdPedido = idpedido;
            compra.IdCubo = idcubo;
            compra.IdUsuario = idusuario;
            compra.FechaPedido = fecha;

            this.context.Pedidos.Add(compra);
            await this.context.SaveChangesAsync();
        }
        

    }
}
