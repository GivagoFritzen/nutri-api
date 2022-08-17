using CrossCutting.Authentication;
using Domain.DTO.Token;
using System;

namespace DomainTest.DTO
{
    public static class TokenDTOFake
    {
        public static TokenDTO GetFake(string name, string email, Guid id)
        {
            return new TokenDTO()
            {
                Name = name,
                Email = email,
                Role = Permissoes.Nutricionista,
                Id = id
            };
        }
    }
}
