using System.ComponentModel.DataAnnotations;

namespace EmprestimoCaixa.Dtos
{
    public class ProdutoDTO
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int PrazoMaximoMeses { get; set; }
        [Required]
        public decimal TaxaJurosAnual { get; set; }
    }
}