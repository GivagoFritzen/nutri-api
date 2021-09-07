using FluentValidation.Results;
using System.Linq;

namespace Application.ViewModel
{
    public class ResponseView
    {
        public string[] Errors { get; set; }
        public object Body { get; set; }

        public ResponseView(object body)
        {
            Body = body;
        }

        public ResponseView(string[] errors)
        {
            Errors = errors;
        }

        public ResponseView(ValidationResult validationResult)
        {
            Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
        }
    }
}
