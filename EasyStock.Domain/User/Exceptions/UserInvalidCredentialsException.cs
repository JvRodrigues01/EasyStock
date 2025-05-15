using EasyStock.SharedKernel.Core.Exceptions;

namespace EasyStock.Domain.User.Exceptions
{
    public class UserInvalidCredentialsException : AuthoritativeException
    {
        public override string Message { get; } =
            "Credenciais inválidas";

        public UserInvalidCredentialsException(string message)
        {
            Message = message;
        }
    }
}
