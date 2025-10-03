using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Services.Interfaces.Juros;

namespace EmprestimoCaixa.Services.Juros
{
    public class JurosPriceService : IJurosService
    {
        public decimal ConverterTaxaAnualParaMensal(decimal taxaAnual)
        {
            double taxaAnualDecimal = (double)taxaAnual / 100;

            // Calcula taxa mensal equivalente: (1 + i_anual)^(1/12) - 1
            double taxaMensal = Math.Pow(1 + taxaAnualDecimal, 1.0 / 12.0) - 1;
            return (decimal)taxaMensal;
            //return (decimal)Math.Pow((double)(1 + taxaAnual), 1.0 / 12) - 1;
        }

        public decimal CalcularParcelaFixaMensal(PedidoEmprestimoDTO pedidoEmprestimoDTO, decimal taxaAnual)
        {
            var taxaMensal = ConverterTaxaAnualParaMensal(taxaAnual);
            return pedidoEmprestimoDTO.ValorSolicitado * (taxaMensal / (1 - (decimal)Math.Pow(1 + (double)taxaMensal, -pedidoEmprestimoDTO.PrazoMeses)));
        }

        public decimal CalcularTaxaDeJurosEfetivaMensal(decimal taxaAnual)
        {
            double taxaAnualDecimal = (double)taxaAnual / 100;
            return (decimal)Math.Pow(1 + taxaAnualDecimal, 1.0 / 12) - 1;
        }
    }
}