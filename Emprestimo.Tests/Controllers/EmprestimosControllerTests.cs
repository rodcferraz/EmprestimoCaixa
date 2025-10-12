using EmprestimoCaixa.Controllers;
using EmprestimoCaixa.Data;
using EmprestimoCaixa.Dtos;
using EmprestimoCaixa.Entities;
using EmprestimoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Emprestimo.Tests.ControllersTests
{
    public class EmprestimosControllerTests
    {
        [Fact]
        public void PedidoEmprestimo_ControllerComHttpContextItems_DeveRetornarOk()
        {
            // Arrange
            var produto = new Produto { IdProduto = 1, Nome = "Produto Teste", PrazoMaximoMeses = 12 };

            var pedidoEmprestimoDTO = new PedidoEmprestimoDTO
            {
                IdProduto = 1,
                ValorSolicitado = 1000,
                PrazoMeses = 12
            };

            var simulacaoDTO = new SimulacaoEmprestimoDTO
            {
                Produto = produto,
                MemoriaCalculo = new List<MemoriaCalculoDTO>()
            };

            var emprestimoServiceMock = new Moq.Mock<IEmprestimoService>();

            emprestimoServiceMock
                .Setup(x => x.ValidarEmprestimo(It.IsAny<PedidoEmprestimoDTO>()))
                .Returns(produto);

            emprestimoServiceMock
                .Setup(x => x.SimularEmprestimo(It.IsAny<Produto>(), It.IsAny<PedidoEmprestimoDTO>()))
                .Returns(simulacaoDTO);

            var controller = new EmprestimosController(emprestimoServiceMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            var result = controller.CalcularEmprestimo(pedidoEmprestimoDTO);

            // Assert
            var actionResult = Assert.IsType<ActionResult<SimulacaoEmprestimoDTO>>(result);
            var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
            var dtoResult = Assert.IsType<SimulacaoEmprestimoDTO>(ok.Value);
        }
    }
}
