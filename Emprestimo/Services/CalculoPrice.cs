using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Services.Interfaces;

namespace EmprestimoCaixa.Services
{
    public class CalculoPrice : ICalculoEmprestimo
    {
        public List<MemoriaCalculoDTO> CalcularParcelas(decimal valorEmprestimo, decimal taxaAnual, int numeroParcelas)
        {
            
            var parcelas = new List<MemoriaCalculoDTO>();
            decimal saldoDevedor = valorEmprestimo;

            var taxaMensal = ConverterTaxaAnualParaMensal(taxaAnual);

            // Cálculo da parcela fixa
            decimal parcelaFixa = CalcularParcelaFixaMensal(valorEmprestimo, taxaMensal, numeroParcelas);

            for (int mes = 1; mes <= numeroParcelas; mes++)
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

        public decimal ConverterTaxaAnualParaMensal(decimal taxaAnual)
        {
            return (decimal)Math.Pow((double)(1 + taxaAnual), 1.0 / 12) - 1;
        }

        public decimal CalcularParcelaFixaMensal(decimal valorEmprestimo, decimal taxaMensal, int numeroParcelas)
        {
            return valorEmprestimo * (taxaMensal / (1 - (decimal)Math.Pow(1 + (double)taxaMensal, -numeroParcelas)));
        }

        public decimal CalcularTaxaDeJurosEfetivaMensal(decimal taxaAnual)
        {
            double taxaAnualDecimal = (double)taxaAnual / 100;
            return (decimal) Math.Pow(1 + taxaAnualDecimal, 1.0 / 12) - 1;
        }

        public SimulacaoEmprestimoDTO SimularEmprestimo(Produto produtoSimulacao, PedidoEmprestimoDTO pedidoEmprestimoSimulacao)
        {
            var calcularJurosMensal = ConverterTaxaAnualParaMensal(produtoSimulacao.TaxaJurosAnual);
            var calcularTaxaJurosEfetivaMensal = CalcularTaxaDeJurosEfetivaMensal(produtoSimulacao.TaxaJurosAnual);
            var calcularParcelaFixaMensal = CalcularParcelaFixaMensal(pedidoEmprestimoSimulacao.ValorSolicitado,
                                                                      calcularJurosMensal,
                                                                      pedidoEmprestimoSimulacao.PrazoMeses);
            return new SimulacaoEmprestimoDTO()
            {
                Produto = produtoSimulacao,
                ValorSolicitado = pedidoEmprestimoSimulacao.ValorSolicitado,
                PrazoMeses = pedidoEmprestimoSimulacao.PrazoMeses,
                TaxaJurosEfetivaMensal = calcularTaxaJurosEfetivaMensal,
                ValorTotalComJuros = pedidoEmprestimoSimulacao.PrazoMeses * calcularParcelaFixaMensal,
                ParcelaMensal = calcularParcelaFixaMensal,
                MemoriaCalculo = CalcularParcelas(pedidoEmprestimoSimulacao.ValorSolicitado,
                                                  produtoSimulacao.TaxaJurosAnual,
                                                  pedidoEmprestimoSimulacao.PrazoMeses)
            };
        }
    }
}