using FluentValidation.Results;
using System.Linq;
using System.Net;

namespace Application.ViewModel
{
    public class ResponseView
    {
        private HttpStatusCode statusCode { get; set; }
        public string[] messages { get; set; }
        public object body { get; set; }

        public ResponseView() { }

        public void AddMessageError(ValidationResult validationResult)
        {
            messages = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
        }
    }
}
