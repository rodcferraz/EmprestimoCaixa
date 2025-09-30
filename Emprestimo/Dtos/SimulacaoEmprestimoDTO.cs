using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Data
{
    public class SimulacaoEmprestimoDTO
    {
        public Produto Produto { get; set; }
        public decimal ValorSolicitado { get; set; }
        public int PrazoMeses { get; set; }
        public decimal TaxaJurosEfetivaMensal { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ParcelaMensal { get; set; }
        public List<MemoriaCalculoDTO> MemoriaCalculo { get; set; } = [];
    }

    public class MemoriaCalculoDTO
    {
        public int Mes { get; set; }
        public decimal SaldoDevedorInicial { get; set; }
        public decimal Juros { get; set; }
        public decimal Amortizacao { get; set; }
        public decimal SaldoDevedorFinal { get; set; }
    }
}