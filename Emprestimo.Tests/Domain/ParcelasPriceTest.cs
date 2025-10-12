namespace Emprestimo.Tests.DomainTests
{
    public class ParcelasPriceTest
    {
        [Fact]
        public void CalcularParcelas_ShouldReturnCorrectInstallments()
        {
            // Arrange
            var parcelasPrice = new EmprestimoCaixa.Domain.ParcelasPrice();
            var pedidoEmprestimoDTO = new EmprestimoCaixa.Dtos.PedidoEmprestimoDTO
            {
                ValorSolicitado = 1000m,
                PrazoMeses = 3
            };
            decimal taxaMensal = 0.01m; // 1%
            decimal parcelaFixa = 337.03m; // Example fixed installment
            // Act
            var result = parcelasPrice.CalcularParcelas(pedidoEmprestimoDTO, taxaMensal, parcelaFixa);
            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0].Mes);
            Assert.Equal(10.00m, result[0].Juros);
            Assert.Equal(327.03m, result[0].Amortizacao);
            Assert.Equal(1000.00m, result[0].SaldoDevedorInicial);
            Assert.Equal(672.97m, result[0].SaldoDevedorFinal);
            Assert.Equal(2, result[1].Mes);
            Assert.Equal(6.73m, result[1].Juros);
            Assert.Equal(330.30m, result[1].Amortizacao);
            Assert.Equal(672.97m, result[1].SaldoDevedorInicial);
            Assert.Equal(342.67m, result[1].SaldoDevedorFinal);
            Assert.Equal(3, result[2].Mes);
            Assert.Equal(3.43m, result[2].Juros);
            Assert.Equal(333.60m, result[2].Amortizacao);
            Assert.Equal(342.67m, result[2].SaldoDevedorInicial);
            Assert.Equal(9.07m, result[2].SaldoDevedorFinal);
        }
    }
}
