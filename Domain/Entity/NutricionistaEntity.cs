using System.Collections.Generic;

namespace Domain.Entity
{
    public class NutricionistaEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public List<PacienteEntity> Pacientes { get; set; }
    }
}
