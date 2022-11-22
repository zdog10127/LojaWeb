using API.Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Interfaces
{
    public interface IRepositorioCategoria
    {
        Task<List<Categoria>> ListarTodosOsCategoriaAsync();
        Task<Categoria> ListarCategoriaPorIdAsync(int idCategoria);
        Task<Categoria> GravarCategoriaAsync(Categoria categoria);
        Task<bool> AtualizarCategoriaAsync(Categoria categoria);
        Task<bool> DeletarCategoriaAsync(Categoria categoria);
    }
}
