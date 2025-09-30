using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Infraestrutura.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutosAsync();
        Task<Produto> GetProdutoPorIdAsync(int idProduto);
        Task CadastrarProduto(Produto produto);
        Task<Produto> AlterarProduto(int idProduto, Produto produto);
        Task DeletarProduto(int idProduto);
    }
}