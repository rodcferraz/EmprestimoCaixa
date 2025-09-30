using System.Threading.Tasks;
using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Enums;
using EmprestimoCaixa.Infraestrutura;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using EmprestimoCaixa.Services.Interfaces;

namespace EmprestimoCaixa.Services
{
    public class ServiceEmprestimo : IServiceEmprestimo
    {
        private ModeloEmprestimoEnum MODELO_EMPRESTIMO = 0;
        
        private readonly IProdutoRepository _produtoRepository;

        public ServiceEmprestimo(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<SimulacaoEmprestimoDTO> SimularEmprestimo(PedidoEmprestimoDTO pedidoEmprestimoDTO)
        {
            try
            {
                Produto produtoDb = await _produtoRepository.GetProdutoPorIdAsync(pedidoEmprestimoDTO.IdProduto);

                ICalculoEmprestimo emprestimo = MODELO_EMPRESTIMO switch
                {
                    0 => new CalculoPrice(),
                    _ => throw new Exception("")
                };

                return emprestimo.SimularEmprestimo(produtoDb, pedidoEmprestimoDTO);

            }
            catch (Exception exceptionError)
            {
                throw new Exception("", exceptionError);
            }

           
        }
    }
}