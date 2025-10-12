using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Tests
{
    public class AppSettingsTest
    {
        [Fact]
        public void AppSettings_ShouldReturn_CorrectMetodoEmprestimo()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"MetodoEmprestimo", "SAC"}
            };
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            var appSettings = new EmprestimoCaixa.AppSettings(configuration);
            // Act
            var metodoEmprestimo = appSettings.MetodoEmprestimo;
            // Assert
            Assert.Equal("SAC", metodoEmprestimo);
        }
    }
}
