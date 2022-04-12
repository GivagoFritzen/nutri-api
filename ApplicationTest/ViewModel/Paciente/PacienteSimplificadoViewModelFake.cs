using Application.ViewModel.Pacientes;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteSimplificadoViewModelFake
    {
        public static List<PacienteSimplificadoViewModel> GetListDifferentIdFake(Guid id)
        {
            return new List<PacienteSimplificadoViewModel>() {
                new PacienteSimplificadoViewModel()
                {
                    Id = id,
                    Nome = "nome",
                    Sobrenome = "sobrenome",
                    Email = "teste@provedor.com",
                    Telefone = "99999999"
                }
            };
        }
    }
}
