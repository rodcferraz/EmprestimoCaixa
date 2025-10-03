using Emprestimo.Mappers;
using EmprestimoCaixa.Enums;
using EmprestimoCaixa.Services.Interfaces.Juros;
using EmprestimoCaixa.Services.Juros;

namespace EmprestimoCaixa.Domain
{
    public class JurosFactory : IJurosFactory
    {
        private readonly AppSettings _appSettings;
       
        public JurosFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IJurosService RetornarJuros()
        {
            var emprestimo = ModeloEmprestimoMapper.FromStringToModeloEmprestimoEnum(_appSettings.MetodoEmprestimo);

            IJurosService jurosFactory = emprestimo switch
            {
                ModeloEmprestimoEnum.Price => new JurosPriceService(),
                ModeloEmprestimoEnum.SAC => throw new Exception(),
                _ => throw new Exception()
            };

            return jurosFactory;
        }
    }
}