using Application.ViewModel.Admin;
using Domain.Entity;
using Domain.Event;
using System;

namespace Application.Mapper
{
    public static class MapperAdmin
    {
        public static AdminEntity ToEntity(this AdminAdicionarViewModel adminViewModel)
        {
            return new AdminEntity()
            {
                Id = Guid.NewGuid(),
                Email = adminViewModel.Email,
                Senha = adminViewModel.Senha
            };
        }

        public static AdminEntity ToViewModel(this AdminEntity adminViewModel)
        {
            return new AdminEntity()
            {
                Id = adminViewModel.Id,
                Email = adminViewModel.Email
            };
        }

        public static AdminsEvent ToAdminEvent(this AdminEntity paciente)
        {
            return new AdminsEvent()
            {
                Id = paciente.Id,
                Email = paciente.Email
            };
        }
    }
}
