using Emprestimo.Mappers;
using EmprestimoCaixa.Data;
using EmprestimoCaixa.Domain;
using EmprestimoCaixa.Domain.Interfaces;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Dtos.Builder;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Enums;
using EmprestimoCaixa.Services.Interfaces;
using EmprestimoCaixa.Services.Interfaces.Juros;

namespace EmprestimoCaixa.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IJurosFactory _jurosFactory;
        private readonly AppSettings _appSettings;

        public EmprestimoService(IJurosFactory jurosFactory, AppSettings appSettings)
        {
            _jurosFactory = jurosFactory;
            _appSettings = appSettings;
        }

        public SimulacaoEmprestimoDTO SimularEmprestimo(Produto produto, PedidoEmprestimoDTO pedidoEmprestimoDTO)
        {
            try
            {
                var modeloEmprestimo = ModeloEmprestimoMapper.
                                            FromStringToModeloEmprestimoEnum(_appSettings.MetodoEmprestimo);

                IJurosService jurosService = _jurosFactory.RetornarJuros();

                IParcelasEmprestimo emprestimo = modeloEmprestimo switch
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
                throw new Exception(exceptionError.Message, exceptionError);
            }
        }
    }
}