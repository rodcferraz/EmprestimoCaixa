using EmprestimoCaixa.Enums;
using EmprestimoCaixa.Services.Interfaces.Juros;
using EmprestimoCaixa.Services.Juros;

namespace EmprestimoCaixa.Domain
{
    public class JurosFactory : IJurosFactory
    {
        private ModeloEmprestimoEnum MODELO_EMPRESTIMO = ModeloEmprestimoEnum.Price;

        public IJurosService RetornarJuros()
        {
            IJurosService jurosFactory = MODELO_EMPRESTIMO switch
            {
                ModeloEmprestimoEnum.Price => new JurosPriceService(),
                ModeloEmprestimoEnum.SAC => throw new Exception(),
                _ => throw new Exception()
            };
            
            return jurosFactory;
        }
    }
}