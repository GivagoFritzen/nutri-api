using FluentValidation.Results;
using System.Linq;

namespace Application.ViewModel
{
    public class ErrorViewModel : BaseViewModel
    {
        public string[] Errors { get; set; }

        public ErrorViewModel() { }

        public ErrorViewModel(ValidationResult validationResult)
        {
            Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
        }
    }
}
