using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using EmprestimoCaixa.Services.Interfaces;

namespace EmprestimoCaixa.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto? AlterarProduto(int idProduto, Produto produto)
        {
            var produtoDb = GetProdutoPorId(idProduto);

            if (produtoDb == null)
            {
                return null;
            }

            produtoDb.Nome = produto.Nome;
            produtoDb.PrazoMaximoMeses = produto.PrazoMaximoMeses;
            produtoDb.TaxaJurosAnual = produto.TaxaJurosAnual;

            return _produtoRepository.AlterarProduto(produtoDb);
        }

        public bool CadastrarProduto(Produto produto)
        {
            return _produtoRepository.CadastrarProduto(produto);
        }

        public bool DeletarProduto(int idProduto)
        {
            var produtoDb = GetProdutoPorId(idProduto);

            if (produtoDb == null)
            {
                return false;
            }

            return _produtoRepository.DeletarProduto(produtoDb);
        }

        public Produto? GetProdutoPorId(int idProduto)
        {
            return _produtoRepository.GetProdutoPorId(idProduto);
        }

        public List<Produto>? GetTodosProdutos()
        {
            return _produtoRepository.GetProdutos();
        }
    }
}