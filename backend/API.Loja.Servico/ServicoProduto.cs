using API.Loja.Dominio.Entidades;
using API.Loja.Dominio.Interfaces;
using API.Loja.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Servico
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ServicoProduto()
        {
            _repositorioProduto = new RepositorioProduto();
        }

        public async Task<List<Produtos>> ListarTodosOsProdutosAsync()
        {
            var listaProdutos = await _repositorioProduto.ListarTodosOsProdutosAsync();
            return listaProdutos;
        }

        public async Task<Produtos> ListarProdutosPorIdAsync(int idProduto)
        {
            var produtoCodigo = await _repositorioProduto.ListarProdutosPorIdAsync(idProduto);
            return produtoCodigo;
        }

        public async Task<RetornoDto> GravarProdutoAsync(Produtos produtos)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioProduto.GravarProdutoAsync(produtos);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Gravar Produtos";
                retornoDto.MensagemDeErro = $"Erro no processo de gravar Produto";
            }

            return await Task.FromResult(retornoDto);
        }

        public async Task<RetornoDto> AtualizarProdutoAsync(Produtos produtos)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioProduto.AtualizarProdutoAsync(produtos);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Atualizar Produtos";
                retornoDto.MensagemDeErro = $"Erro no processo de atualizar Produto";
            }

            return await Task.FromResult(retornoDto);
        }

        public async Task<RetornoDto> DeletarProdutoAsync(Produtos produtos)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioProduto.DeletarProdutoAsync(produtos);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Deletar Produtos";
                retornoDto.MensagemDeErro = $"Erro no processo de deletar o Produto";
            }

            return await Task.FromResult(retornoDto);
        }
    }
}
