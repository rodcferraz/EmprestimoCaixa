using EmprestimoCaixa;
using EmprestimoCaixa.Domain;
using EmprestimoCaixa.Services.Juros;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Emprestimo.Tests.DomainTests
{
    public class JurosFactoryTest
    {
        [Fact]
        public void RetornarJuros_ShouldReturnJurosPrice_WhenMetodoEmprestimoOnAppSettingsIsPrice()
        {
            //Arrange
            var configStub = new Mock<IConfigurationRoot>();

            configStub
                .Setup(x => x["MetodoEmprestimo"])
                .Returns("Price")
                .Verifiable();

            var appSettings = new AppSettings(configStub.Object);

            //Act
            var jurosFactory = new JurosFactory(appSettings);
            var jurosService = jurosFactory.RetornarJuros();

            //Assert
            Assert.IsType<JurosPriceService>(jurosService);
        }

        [Fact]
        public void ReturnarJuros_ShouldThrowException_WhenMetodoEmprestimoIsSAC()
        {
            //Arrange
            var configStub = new Mock<IConfigurationRoot>();

            configStub
                .Setup(x => x["MetodoEmprestimo"])
                .Returns("SAC")
                .Verifiable();

            var appSettings = new AppSettings(configStub.Object);

            //Act
            var jurosFactory = new JurosFactory(appSettings);

            //Assert
            Assert.Throws<Exception>(() => jurosFactory.RetornarJuros());
        }
    }
}