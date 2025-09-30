using System.ComponentModel.DataAnnotations;

namespace EmprestimoCaixa.Dtos
{
    public class PedidoEmprestimoDTO
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public decimal ValorSolicitado { get; set; }
        [Required]
        public int PrazoMeses { get; set; }
    }
}