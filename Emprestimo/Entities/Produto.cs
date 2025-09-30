using System.ComponentModel.DataAnnotations;

namespace EmprestimoCaixa.Entities
{
    public class Produto
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal TaxaJurosAnual { get; set; }
        [Required]
        public int PrazoMaximoMeses { get; set; } 

    }
}