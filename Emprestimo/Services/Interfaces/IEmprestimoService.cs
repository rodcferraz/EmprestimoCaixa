using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Services.Interfaces
{
    public interface IEmprestimoService
    {
        SimulacaoEmprestimoDTO SimularEmprestimo (Produto produto, PedidoEmprestimoDTO pedidoEmprestimoDTO);
    }
}