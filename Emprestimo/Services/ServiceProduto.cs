using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Services.Interfaces;

namespace EmprestimoCaixa.Services
{
    public class ServiceProduto : IServiceProduto
    {
        public Task<Produto> AlterarProduto(int idProduto, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task DeletarProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoPorIdAsync(int idProduto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutosAsync()
        {
            throw new NotImplementedException();
        }
    }
}