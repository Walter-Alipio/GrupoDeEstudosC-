using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ByteBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteService service;

        public ContaCorrenteController(IContaCorrenteService service)
        {
            this.service = service;
        }

        // GET: api/ContaCorrente
        [HttpGet]
        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesAsync()
        {
            return await this.service.BuscaContasCorrentesAsync();
        }

        // GET: api/ContaCorrente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrenteViewModel>> BuscaContaCorrentePorIdAsync(int id)
        {
            var conta = await this.service.BuscaContaCorrentePorIdAsync(id);

            if (conta == null)
            {
                return new NotFoundResult();
            }

            return conta;
        }

        // GET: api/ContaCorrente/cpf/12345678901
        [HttpGet("cpf/{cpf}")]
        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorCpfTitularAsync(string cpf)
        {
            return await this.service.BuscaContasCorrentesPorCpfTitularAsync(cpf);
        }

        // GET: api/ContaCorrente/nome/Joao
        [HttpGet("nome/{nome}")]
        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorNomeTitularAsync(string nome)
        {
            return await this.service.BuscaContasCorrentesPorNomeTitularAsync(nome);
        }

        // GET: api/ContaCorrente/paginado[?pagina=1&tamanhoPagina=10]
        [HttpGet("paginado")]
        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPaginadoAsync(int pagina = 1, int tamanhoPagina = 10)
        {
            return await this.service.BuscaContasCorrentesPaginadoAsync(pagina, tamanhoPagina);
        }

        //POST: api/ContaCorrente/clienteId/1
        [HttpPost("clienteId/{id}")]
        public async Task<ActionResult<ContaCorrenteViewModel>> PostContaCorrente(int id, ContaRequest contaRequest)
        {
            ContaCorrenteViewModel? contaCorrenteView;
            try
            {
                contaCorrenteView = await this.service.CriaContaAsync(id, contaRequest);
            }
            catch (ValidationException e)
            {

                return BadRequest(e.Message);
            }

            if (contaCorrenteView is null) return this.NotFound($"Cliente id: {id} não encontrado.");

            return this.CreatedAtAction("BuscaContaCorrentePorIdAsync",
             new { id = contaCorrenteView.Id }, contaCorrenteView);
        }
    }
}