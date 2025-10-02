using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmprestimoCaixa.Filters
{
    public class ValidarEmprestimoFilter : IActionFilter
    {
        private readonly IProdutoRepository _produtoRepository;

        public ValidarEmprestimoFilter(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("pedidoEmprestimoDTO", out var dto) &&
                dto is PedidoEmprestimoDTO pedidoEmprestimoDTO)
            {
                if (pedidoEmprestimoDTO != null && pedidoEmprestimoDTO.IdProduto != 0)
                {
                    var produtoDb = _produtoRepository.GetProdutoPorId(pedidoEmprestimoDTO.IdProduto);

                    if (produtoDb == null)
                    {
                        context.Result = new BadRequestObjectResult("Id de Produto não encontrado.");
                        return;
                    }

                    if (pedidoEmprestimoDTO.PrazoMeses > produtoDb.PrazoMaximoMeses)
                    {
                        context.Result = new BadRequestObjectResult("Prazo solicitado é superior ao prazo do produto.");
                        return;
                    }

                    context.HttpContext.Items["Produto"] = produtoDb;
                }
            }
        }
    }
}