using EmprestimoCaixa.Enums;

namespace Emprestimo.Mappers
{
    public static class ModeloEmprestimoMapper
    {
        public static ModeloEmprestimoEnum FromStringToModeloEmprestimoEnum(string modeloEmprestimo)
        {
            return Enum.Parse<ModeloEmprestimoEnum>(modeloEmprestimo);
        }
    }
}