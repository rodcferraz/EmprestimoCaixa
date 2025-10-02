using EmprestimoCaixa.Data;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Infraestrutura.Data;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCaixa.Infraestrutura
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EmprestimoCaixaDbContext _emprestimoCaixaDbContext;
        
        public ProdutoRepository(EmprestimoCaixaDbContext emprestimoCaixaDbContext)
        {
            _emprestimoCaixaDbContext = emprestimoCaixaDbContext;
        }

        public Produto? AlterarProduto(Produto produto)
        {
            _emprestimoCaixaDbContext.Produtos.Update(produto);
            var resultado = _emprestimoCaixaDbContext.SaveChanges();

            if (resultado == 0)
            {
                return null;
            }
            
            return produto;
        }

        public bool CadastrarProduto(Produto produto)
        {
            _emprestimoCaixaDbContext.Produtos.Add(produto);
            var resultado = _emprestimoCaixaDbContext.SaveChanges();

            if (resultado == 0)
            {
                return false;
            }

            return true;
        }

        public bool DeletarProduto(Produto produto)
        {
            var removido = _emprestimoCaixaDbContext.Produtos.Remove(produto);

            if (removido == null)
            {
                return false;
            }

            return true;
        }

        public Produto? GetProdutoPorId(int idProduto)
        {
            return _emprestimoCaixaDbContext.Produtos.Find(idProduto);
        }

        public List<Produto>? GetProdutos()
        {
            return _emprestimoCaixaDbContext.Produtos.ToList();
        }
    }
}