using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;

namespace EmprestimoCaixa.Domain.Interfaces
{
    public interface IParcelasEmprestimo
    {
        public List<MemoriaCalculoDTO> CalcularParcelas(PedidoEmprestimoDTO pedidoEmprestimoDTO, decimal taxaMensal, decimal parcelaFixa);

    }
}