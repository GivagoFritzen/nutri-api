using Application.ViewModel;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        public void Add(PacienteViewModel pacienteViewModel);

        public void Update(PacienteViewModel pacienteViewModel);

        public void Remove(PacienteViewModel pacienteViewModel);

        IEnumerable<PacienteViewModel> GetAll();

        PacienteViewModel GetById(int id);
    }
}