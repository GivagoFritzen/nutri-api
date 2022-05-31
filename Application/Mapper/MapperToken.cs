﻿using Application.ViewModel.Login;
using CrossCutting.Authentication;
using Domain.DTO.Token;
using Domain.Event;

namespace Application.Mapper
{
    public static class MapperToken
    {
        public static TokenEvent ToEvent(this LoginTokenDTO loginTokenDTO)
        {
            return loginTokenDTO == null ? null : new TokenEvent()
            {
                RefreshToken = loginTokenDTO.RefreshToken,
                ExpireAt = AuthenticationSettings.ExpireTime
            };
        }

        public static LoginTokenViewModel ToViewModel(this LoginTokenDTO loginTokenDTO)
        {
            return loginTokenDTO == null ? null : new LoginTokenViewModel()
            {
                Token = loginTokenDTO.Token,
                RefreshToken = loginTokenDTO.RefreshToken
            };
        }
    }
}
