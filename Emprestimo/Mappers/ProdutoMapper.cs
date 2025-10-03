using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto FromProdutoDtoToProduto(ProdutoDTO produtoDto)
        {
            return new Produto
            {
                Nome = produtoDto.Nome,
                TaxaJurosAnual = produtoDto.TaxaJurosAnual,
                PrazoMaximoMeses = produtoDto.PrazoMaximoMeses,
            };
        }
    }
}