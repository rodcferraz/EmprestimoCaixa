using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Infraestrutura.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto>? GetProdutos();
        Produto? GetProdutoPorId(int idProduto);
        bool CadastrarProduto(Produto produto);
        Produto? AlterarProduto(Produto produto);
        bool DeletarProduto(Produto produto);
    }
}