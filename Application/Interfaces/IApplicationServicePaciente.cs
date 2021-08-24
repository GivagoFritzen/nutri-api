using Application.DTO;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        public void Add(PacienteDTO pacienteDTO);

        public void Update(PacienteDTO pacienteDTO);

        public void Remove(PacienteDTO pacienteDTO);

        IEnumerable<PacienteDTO> GetAll();

        PacienteDTO GetById(int id);
    }
}