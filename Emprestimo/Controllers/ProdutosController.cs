using EmprestimoCaixa.Data;
using EmprestimoCaixa.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        public ProdutosController()
        {
            
        }


        [HttpGet("todos")]
        public async Task<ActionResult<Produto>> GetEmprestimos()
        {
            return Ok();
        }
    }
}