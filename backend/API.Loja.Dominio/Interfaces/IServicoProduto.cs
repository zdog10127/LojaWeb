using API.Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Interfaces
{
    public interface IServicoProduto
    {
        Task<List<Produtos>> ListarTodosOsProdutosAsync();
        Task<Produtos> ListarProdutosPorIdAsync(int idProduto);
        Task<RetornoDto> GravarProdutoAsync(Produtos produtos);
        Task<RetornoDto> AtualizarProdutoAsync(Produtos produtos);
        Task<RetornoDto> DeletarProdutoAsync(Produtos produtos);
    }
}
