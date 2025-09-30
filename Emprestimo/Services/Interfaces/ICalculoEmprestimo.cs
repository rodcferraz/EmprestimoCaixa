using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Services.Interfaces
{
    public interface ICalculoEmprestimo
    {
        decimal ConverterTaxaAnualParaMensal(decimal taxaAnual);
        decimal CalcularParcelaFixaMensal(decimal valorEmprestimo, decimal taxaMensal, int numeroParcelas);
        decimal CalcularTaxaDeJurosEfetivaMensal(decimal taxaAnual);
        List<MemoriaCalculoDTO> CalcularParcelas(decimal valorEmprestimo, decimal taxaMensal, int numeroParcelas);
        SimulacaoEmprestimoDTO SimularEmprestimo(Produto produtoSimulacao, PedidoEmprestimoDTO pedidoEmprestimoSimulacao);
    }
}