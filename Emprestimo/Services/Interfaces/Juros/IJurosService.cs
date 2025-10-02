using EmprestimoCaixa.Dtos;

namespace EmprestimoCaixa.Services.Interfaces.Juros
{
    public interface IJurosService
    {
        public decimal ConverterTaxaAnualParaMensal(decimal taxaAnual);
        public decimal CalcularParcelaFixaMensal(PedidoEmprestimoDTO pedidoEmprestimoDTO, decimal taxaAnual);
        public decimal CalcularTaxaDeJurosEfetivaMensal(decimal taxaAnual);
    }
}