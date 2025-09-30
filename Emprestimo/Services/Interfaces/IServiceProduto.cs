using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Services.Interfaces
{
    public interface IServiceProduto
    {
        Task<Produto> GetProdutosAsync();
        Task<Produto> GetProdutoPorIdAsync(int idProduto);
        Task CadastrarProduto(Produto produto);
        Task<Produto> AlterarProduto(int idProduto, Produto produto);
        Task DeletarProduto(int idProduto);
    }
}