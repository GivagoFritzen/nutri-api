using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        public ResponseView Add(PacienteViewModel pacienteViewModel);

        public void Update(PacienteViewModel pacienteViewModel);

        public void Remove(PacienteViewModel pacienteViewModel);

        Task<IEnumerable<PacienteViewModel>> GetAll();

        Task<PacienteViewModel> GetById(Guid id);
    }
}