using EmprestimoCaixa.Data;
using EmprestimoCaixa.Domain.Interfaces;
using EmprestimoCaixa.Dtos;

namespace EmprestimoCaixa.Domain
{
    public class ParcelasPrice : IParcelasEmprestimo
    {
        public List<MemoriaCalculoDTO> CalcularParcelas(PedidoEmprestimoDTO pedidoEmprestimoDTO,
                                                        decimal taxaMensal,
                                                        decimal parcelaFixa)
        {

            var parcelas = new List<MemoriaCalculoDTO>();
            decimal saldoDevedor = pedidoEmprestimoDTO.ValorSolicitado;

            for (int mes = 1; mes <= pedidoEmprestimoDTO.PrazoMeses; mes++)
            {
                decimal juros = saldoDevedor * taxaMensal;
                decimal amortizacao = parcelaFixa - juros;

                parcelas.Add(new MemoriaCalculoDTO
                {
                    Mes = mes,
                    Juros = Math.Round(juros, 2),
                    Amortizacao = Math.Round(amortizacao, 2),
                    SaldoDevedorInicial = Math.Round(Math.Max(saldoDevedor, 0), 2),
                    SaldoDevedorFinal = Math.Round(Math.Max(saldoDevedor, 0), 2) - Math.Round(amortizacao, 2)
                });

                saldoDevedor -= amortizacao;
            }

            return parcelas;
        }
    }
}