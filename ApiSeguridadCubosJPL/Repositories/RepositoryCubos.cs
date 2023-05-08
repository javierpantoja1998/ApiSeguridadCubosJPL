﻿using ApiSeguridadCubosJPL.Data;
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
        public async Task<Cubo> FindCuboAsync(string marca)
        {
            return await
                this.context.Cubos.FirstOrDefaultAsync
                (x => x.Marca == marca);
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
       
        
    }
}
