using API.Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Interfaces
{
    public interface IRepositorioProduto
    {
        Task<List<Produtos>> ListarTodosOsProdutosAsync();
        Task<Produtos> ListarProdutosPorIdAsync(int idProduto);
        Task<Produtos> GravarProdutoAsync(Produtos produtos);
        Task<bool> AtualizarProdutoAsync(Produtos produtos);
        Task<bool> DeletarProdutoAsync(Produtos produtos);
    }
}
