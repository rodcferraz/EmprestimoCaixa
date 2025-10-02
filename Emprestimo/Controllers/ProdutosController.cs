using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Mappers;
using EmprestimoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _productService;

        public ProdutosController(IProdutoService productService)
        {
            _productService = productService;
        }

        [HttpGet("listar")]
        public ActionResult<Produto> GetListarProdutos()
        {
            var produtos = _productService.GetTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{idProduto}")]
        public ActionResult<Produto> Get(int idProduto)
        {
            var produto = _productService.GetProdutoPorId(idProduto);

            return Ok(produto);
        }

        [HttpPut("{idProduto}")]
        public ActionResult<Produto> AlterarProduto(int idProduto, ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid || idProduto == 0)
            {
                return BadRequest("Parametros não informados");
            }

            var produto = ProdutoMapper.FromProdutoDtoToProduto(produtoDto);

            var produtoDb = _productService.AlterarProduto(idProduto, produto);

            return Ok(produtoDb);
        }

        [HttpPost]
        public ActionResult<Produto> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros não informados");
            }

            var produto = ProdutoMapper.FromProdutoDtoToProduto(produtoDto);

            var sucesso = _productService.CadastrarProduto(produto);

            if (sucesso)
            {
                return BadRequest("Erro ao adicionar produto");
            }

            return Ok("Produto adicionado");
        }
    }
}