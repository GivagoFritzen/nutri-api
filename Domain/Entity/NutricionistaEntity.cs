using System.Collections.Generic;

namespace Domain.Entity
{
    public class NutricionistaEntity : UserEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public List<PacienteEntity> Pacientes { get; set; }
    }
}
