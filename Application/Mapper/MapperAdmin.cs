using Application.ViewModel.Admin;
using Domain.Entity;
using Domain.Event;
using System;

namespace Application.Mapper
{
    public static class MapperAdmin
    {
        public static AdminsEntity ToEntity(this AdminAdicionarViewModel adminViewModel)
        {
            return adminViewModel == null ? null : new AdminsEntity()
            {
                Id = Guid.NewGuid(),
                Email = adminViewModel.Email,
                Senha = adminViewModel.Senha
            };
        }

        public static AdminAdicionarViewModel ToViewModel(this AdminsEntity entity)
        {
            return entity == null ? null : new AdminAdicionarViewModel()
            {
                Email = entity.Email,
                Senha = entity.Senha
            };
        }

        public static AdminEvent ToAdminEvent(this AdminsEntity adminEntity)
        {
            return adminEntity == null ? null : new AdminEvent()
            {
                Id = adminEntity.Id,
                Email = adminEntity.Email
            };
        }
    }
}
