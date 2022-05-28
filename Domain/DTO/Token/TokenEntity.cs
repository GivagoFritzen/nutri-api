using CrossCutting.Authentication;
using System;

namespace Domain.DTO.Token
{
    public class TokenDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Permissoes Role { get; set; }
        public Guid Id { get; set; }
    }
}
