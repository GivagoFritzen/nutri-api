using Domain.Entity;

namespace DomainTest.Entity
{
    public static class PacienteEntityFake
    {
        public static PacienteEntity GetPacienteEntityFake()
        {
            return new PacienteEntity()
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
