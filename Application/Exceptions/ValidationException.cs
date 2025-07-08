using System.Net;
using ApplicationCore.Exceptions;

namespace Application.Exceptions;

public class ValidationException : CustomException
{
    public ValidationException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.BadRequest)
    {
    }
}