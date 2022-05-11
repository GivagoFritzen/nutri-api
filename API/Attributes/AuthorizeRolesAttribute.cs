using CrossCutting.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace API.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Permissoes[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(Permissoes), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
