using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.RequestResponse
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; } = default!;
        public string Error { get; set; } = default!;
        public string Message { get; set; } = default!;
        public IReadOnlyCollection<Error> Errors { get; set; } = default!;

        public static Result<T> Success(T value) => new Result<T>
        {
            IsSuccess = true,
            Value = value,
        };

        public static Result<T> Failure(string error) => new Result<T>
        {
            IsSuccess = false,
            Error = error,
        };

        public static Result<T> ErrorResult(string message, IReadOnlyCollection<Error> errors) => new Result<T>
        {
            IsSuccess = false,
            Message = message,
            Errors = errors ?? Array.Empty<Error>()
        };

    }
}
