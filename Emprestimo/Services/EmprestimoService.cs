using EmprestimoCaixa.Data;
using EmprestimoCaixa.Domain;
using EmprestimoCaixa.Domain.Interfaces;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Dtos.Builder;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Enums;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using EmprestimoCaixa.Services.Interfaces;
using EmprestimoCaixa.Services.Interfaces.Juros;

namespace EmprestimoCaixa.Services
{
    public class ServiceEmprestimo : IEmprestimoService
    {
        private ModeloEmprestimoEnum MODELO_EMPRESTIMO = ModeloEmprestimoEnum.Price;
        private readonly IJurosFactory _jurosFactory;

        public ServiceEmprestimo(IJurosFactory jurosFactory)
        {
            _jurosFactory = jurosFactory;
        }

        public SimulacaoEmprestimoDTO SimularEmprestimo(Produto produto, PedidoEmprestimoDTO pedidoEmprestimoDTO)
        {
            try
            {
                IJurosService jurosService = _jurosFactory.RetornarJuros();

                IParcelasEmprestimo emprestimo = MODELO_EMPRESTIMO switch
                {
                    ModeloEmprestimoEnum.Price => new ParcelasPrice(),
                    _ => throw new Exception("")
                };

                var parcelaFixaMensal = jurosService.CalcularParcelaFixaMensal(
                                                                pedidoEmprestimoDTO,
                                                                produto.TaxaJurosAnual);

                var taxaMensal = jurosService.ConverterTaxaAnualParaMensal(produto.TaxaJurosAnual);
                var calculoParcelas = emprestimo.CalcularParcelas(pedidoEmprestimoDTO, taxaMensal, parcelaFixaMensal);

                var solicitacao = new SimulacaoEmprestimoDTOBuilder()
                                  .SetProduto(produto)
                                  .SetEmprestimoSolicitado(pedidoEmprestimoDTO)
                                  .SetTaxaJurosEfetivaMensal(jurosService.CalcularTaxaDeJurosEfetivaMensal(produto.TaxaJurosAnual))
                                  .SetValoresComJuros(parcelaFixaMensal, pedidoEmprestimoDTO.PrazoMeses)
                                  .SetParcelas(calculoParcelas)
                                  .Build();

                return solicitacao;

            }
            catch (Exception exceptionError)
            {
                throw new Exception("", exceptionError);
            }
        }
    }
}