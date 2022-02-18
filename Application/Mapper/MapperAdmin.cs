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
            return adminViewModel == null ? null : new AdminEntity()
            {
                Id = Guid.NewGuid(),
                Email = adminViewModel.Email,
                Senha = adminViewModel.Senha
            };
        }

        public static AdminAdicionarViewModel ToViewModel(this AdminEntity entity)
        {
            return entity == null ? null : new AdminAdicionarViewModel()
            {
                Email = entity.Email,
                Senha = entity.Senha
            };
        }

        public static AdminEvent ToAdminEvent(this AdminEntity adminEntity)
        {
            return adminEntity == null ? null : new AdminEvent()
            {
                Id = adminEntity.Id,
                Email = adminEntity.Email
            };
        }
    }
}
