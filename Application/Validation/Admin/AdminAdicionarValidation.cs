using Application.Commands.Admin;
using FluentValidation;

namespace Application.Validation.Admin
{
    public class AdminAdicionarValidation : AbstractValidator<AdminAdicionarCommand>
    {
        public AdminAdicionarValidation()
        {
        }
    }
}
