using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;

namespace EmprestimoCaixa.Services.Interfaces
{
    public interface IServiceEmprestimo
    {
        Task<SimulacaoEmprestimoDTO> SimularEmprestimo (PedidoEmprestimoDTO pedidoEmprestimoDTO);
    }
}