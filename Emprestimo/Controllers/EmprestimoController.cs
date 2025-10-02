using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Filters;
using EmprestimoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCaixa.Controllers
{
    [ApiController]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;
        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpPost("pedidoEmprestimo")]
        [ServiceFilter(typeof(ValidarEmprestimoFilter))]
        public ActionResult<SimulacaoEmprestimoDTO> CalcularEmprestimo(PedidoEmprestimoDTO pedidoEmprestimoDTO)
        {
            var produto = HttpContext.Items["Produto"] as Produto;

            var resultadoSimulacao = _emprestimoService.SimularEmprestimo(produto, pedidoEmprestimoDTO);
            return Ok(resultadoSimulacao);
        }
    }
}