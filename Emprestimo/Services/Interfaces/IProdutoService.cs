using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Services.Interfaces
{
    public interface IProdutoService
    {
        List<Produto>? GetTodosProdutos();
        Produto? GetProdutoPorId(int idProduto);
        bool CadastrarProduto(Produto produto);
        Produto? AlterarProduto(int idProduto, Produto produto);
        bool DeletarProduto(int idProduto);
    }
}