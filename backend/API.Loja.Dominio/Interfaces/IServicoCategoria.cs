using API.Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Interfaces
{
    public interface IServicoCategoria
    {
        Task<List<Categoria>> ListarTodosOsCategoriaAsync();
        Task<Categoria> ListarCategoriaPorIdAsync(int idCategoria);
        Task<RetornoDto> GravarCategoriaAsync(Categoria categoria);
        Task<RetornoDto> AtualizarCategoriaAsync(Categoria categoria);
        Task<RetornoDto> DeletarCategoriaAsync(Categoria categoria);
    }
}
