using API.Loja.Dominio.Entidades;
using API.Loja.Dominio.Interfaces;
using API.Loja.Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Infra.Repositorio
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly Contexto _contexto;

        public RepositorioCategoria()
        {
            _contexto = new Contexto();
        }

        public async Task<List<Categoria>> ListarTodosOsCategoriaAsync()
        {
            var listarCategorias = await _contexto.Categorias.ToListAsync();
            return listarCategorias;
        }

        public async Task<Categoria> ListarCategoriaPorIdAsync(int idCategoria)
        {
            var categoriaId = await _contexto.Set<Categoria>().Where(x => x.IdCategoria == idCategoria).FirstOrDefaultAsync();
            return categoriaId;
        }

        public async Task<Categoria> GravarCategoriaAsync(Categoria categoria)
        {
            await _contexto.AddRangeAsync(categoria);
            _contexto.SaveChanges();
            return categoria;
        }

        public async Task<bool> AtualizarCategoriaAsync(Categoria categoria)
        {
            var categoriaExistente = await ListarCategoriaPorIdAsync(categoria.IdCategoria);

            if (categoriaExistente == null)
                return false;

            categoriaExistente.CodigoCategoria = categoria.CodigoCategoria;
            categoriaExistente.Descricao = categoria.Descricao;

            _contexto.Categorias.Update(categoriaExistente);
            _contexto.SaveChanges();

            return true;
        }

        public async Task<bool> DeletarCategoriaAsync(Categoria categoria)
        {
            var categoriaExistente = await ListarCategoriaPorIdAsync(categoria.IdCategoria);

            if (categoriaExistente == null)
                return false;

            _contexto.Categorias.Remove(categoriaExistente);
            _contexto.SaveChanges();

            return true;
        }
    }
}
