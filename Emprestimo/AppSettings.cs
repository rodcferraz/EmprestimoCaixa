namespace EmprestimoCaixa
{
    public class AppSettings
    {
        private readonly IConfigurationRoot _settings;

        public string MetodoEmprestimo { get; }

        public AppSettings(IConfigurationRoot settings)
        {
            _settings = settings;
            MetodoEmprestimo = _settings.GetValue<string>("MetodoEmprestimo");
        }


    }
}