using Application.ViewModel.Pacientes;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteAdicionarViewModelFake
    {
        public static PacienteAdicionarViewModel GetFake()
        {
            return new PacienteAdicionarViewModel()
            {
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medida = null,
            };
        }
    }
}
