using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Services.Interfaces.Juros;

namespace EmprestimoCaixa.Services.Juros
{
    public class JurosPriceService : IJurosService
    {
        public decimal ConverterTaxaAnualParaMensal(decimal taxaAnual)
        {
            return (decimal)Math.Pow((double)(1 + taxaAnual), 1.0 / 12) - 1;
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