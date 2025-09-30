using EmprestimoCaixa.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCaixa.Controllers
{
    [ApiController]
    public class EmprestimoController : Controller
    {
        public async Task<ActionResult<SimulacaoEmprestimoDTO>> CalcularEmprestimo()
        {
            return Ok();
        }
    }
}