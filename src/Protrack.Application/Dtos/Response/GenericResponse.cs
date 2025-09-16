using Protrack.Shared.Constants;

namespace Protrack.Application.Dtos.Response;

public class GenericResponse<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public string? Message { get; private set; }
    public string? ErrorCode { get; private set; }
    public int StatusCode { get; private set; }
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.Now;

    private GenericResponse()
    {
    }

    public class Builder(T data)
    {
        private bool _success = true;
        private string? _message;
        private int? _statusCode;
        private string? _errorCode;

        public Builder WithSuccess()
        {
            _success = true;
            return this;
        }

        public Builder WithMessage(string message)
        {
            _message = message;
            return this;
        }

        public Builder WithStatusCode(int statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public Builder WithErrorCode(string errorCode)
        {
            _errorCode = errorCode;
            return this;
        }

        public GenericResponse<T> Build()
        {
            return new GenericResponse<T>
            {
                Data = data,
                Success = _success,
                Message = _message ?? ResponseConstants.DefaultResponse,
                StatusCode = _statusCode ?? StatusCodeConstants.Success,
                ErrorCode = _errorCode
            };
        }
    }
}