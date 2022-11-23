using API.Loja.Dominio.Entidades;
using API.Loja.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.Loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IServicoCategoria _servicoCategoria;

        public CategoriaController(IServicoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = true)]

        public IActionResult HealthCheck()
        {
            StringBuilder informacoes = new StringBuilder();
            informacoes.AppendLine($"API Loja = API.Loja");
            informacoes.AppendLine($"Situação = Saudável");

            return Ok(informacoes.ToString());
        }

        [HttpGet]
        [Route("/categorias")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarTodosOsCategoriaAsync()
        {
            var categorias = await _servicoCategoria.ListarTodosOsCategoriaAsync();

            if (categorias.Count == 0)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(categorias);
        }

        [HttpGet]
        [Route("/categorias/{idCategoria}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarCategoriaPorIdAsync(int idCategoria)
        {
            var categoria = await _servicoCategoria.ListarCategoriaPorIdAsync(idCategoria);
            if (categoria is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }
            return Ok(categoria);
        }

        [HttpPost]
        [Route("/categorias")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GravarCategoriaAsync([FromBody] Categoria categoria)
        {
            var categorias = await _servicoCategoria.ListarCategoriaPorIdAsync(categoria.IdCategoria);

            if (categorias is not null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                detalhesDoProblema.Type = "BadRequest";
                detalhesDoProblema.Title = "Registros Duplicados";
                detalhesDoProblema.Detail = $"Já existe uma cobertura cadastrada para o código {categoria.IdCategoria}. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return BadRequest(detalhesDoProblema);
            }

            var retornoDto = await _servicoCategoria.GravarCategoriaAsync(categoria);

            if (retornoDto.HouveErro == true)
                return retornoDto.RetornarResultado(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.Created, categoria);
            }

        }

        [HttpPut]
        [Route("/categorias/{idCategoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarCategoriaAsync(Categoria categoria)
        {
            var retornoDto = await _servicoCategoria.AtualizarCategoriaAsync(categoria);

            if (retornoDto.HouveErro == true)
            {
                return retornoDto.RetornarResultado(HttpContext.Request.Path);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, categoria);
            }
        }

        [HttpDelete]
        [Route("/categorias/{idCategoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletarCategoriaAsync(int idCategoria)
        {
            var categorias = await _servicoCategoria.ListarCategoriaPorIdAsync(idCategoria);
            if (categorias is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros para o - {idCategoria}.";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            var retornoDto = await _servicoCategoria.DeletarCategoriaAsync(categorias);

            if (retornoDto.HouveErro == true)
                return retornoDto.RetornarResultado(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, categorias);
            }
        }
    }
}
