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
    public class ServicoCategoria : IServicoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ServicoCategoria()
        {
            _repositorioCategoria = new RepositorioCategoria();
        }

        public async Task<List<Categoria>> ListarTodosOsCategoriaAsync()
        {
            var categorias = await _repositorioCategoria.ListarTodosOsCategoriaAsync();
            return categorias;
        }

        public async Task<Categoria> ListarCategoriaPorIdAsync(int idCategoria)
        {
            var categoriaId = await _repositorioCategoria.ListarCategoriaPorIdAsync(idCategoria);
            return categoriaId;
        }

        public async Task<RetornoDto> GravarCategoriaAsync(Categoria categoria)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioCategoria.GravarCategoriaAsync(categoria);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Gravar Categorias";
                retornoDto.MensagemDeErro = $"Erro no processo de gravar Categoria";
            }

            return await Task.FromResult(retornoDto);
        }

        public async Task<RetornoDto> AtualizarCategoriaAsync(Categoria categoria)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioCategoria.AtualizarCategoriaAsync(categoria);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Atualizar Categorias";
                retornoDto.MensagemDeErro = $"Erro no processo de atualizar Categoria";
            }

            return await Task.FromResult(retornoDto);
        }

        public async Task<RetornoDto> DeletarCategoriaAsync(Categoria categoria)
        {
            RetornoDto retornoDto = new();

            var ret = _repositorioCategoria.DeletarCategoriaAsync(categoria);

            if (ret.Exception != null)
            {
                retornoDto.HouveErro = true;
                retornoDto.CodigoErro = "400";
                retornoDto.TituloErro = "Deletar Categorias";
                retornoDto.MensagemDeErro = $"Erro no processo de deletar a Categoria";
            }

            return await Task.FromResult(retornoDto);
        }
    }
}
