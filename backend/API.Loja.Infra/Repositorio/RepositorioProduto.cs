using API.Loja.Dominio.Entidades;
using API.Loja.Dominio.Interfaces;
using API.Loja.Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Infra.Repositorio
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly Contexto _contexto;

        public RepositorioProduto()
        {
            _contexto = new Contexto();
        }

        public async Task<List<Produtos>> ListarTodosOsProdutosAsync()
        {
            var listaProdutos = await _contexto.Produtos.ToListAsync();
            return listaProdutos;
        }

        public async Task<Produtos> ListarProdutosPorIdAsync(int idProduto)
        {
            var produtosId = await _contexto.Set<Produtos>().Where(x => x.IdProduto == idProduto).FirstOrDefaultAsync();
            return produtosId;
        }

        public async Task<Produtos> GravarProdutoAsync(Produtos produtos)
        {
            await _contexto.AddAsync(produtos);
            _contexto.SaveChanges();
            return produtos;
        }

        public async Task<bool> AtualizarProdutoAsync(Produtos produtos)
        {
            var produtosExistentes = await ListarProdutosPorIdAsync(produtos.IdProduto);

            if (produtosExistentes == null)
                return false;

            produtosExistentes.CodigoProduto = produtos.CodigoProduto;
            produtosExistentes.Descricao = produtos.Descricao;
            produtosExistentes.Preço = produtos.Preço;

            _contexto.Produtos.Update(produtosExistentes);
            _contexto.SaveChanges();

            return true;
        }

        public async Task<bool> DeletarProdutoAsync(Produtos produtos)
        {
            var produtoExistente = await ListarProdutosPorIdAsync(produtos.IdProduto);

            if (produtoExistente == null)
                return false;

            _contexto.Produtos.Remove(produtoExistente);
            _contexto.SaveChanges();

            return true;
        }
    }
}
