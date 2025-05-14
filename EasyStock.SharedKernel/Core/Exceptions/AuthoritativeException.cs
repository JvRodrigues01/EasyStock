using EasyStock.SharedKernel.Core.Contracts;
using System.Net;

namespace EasyStock.SharedKernel.Core.Exceptions
{
    public class AuthoritativeException : Exception, IException
    {
        public int Code { get; set; } = (int)HttpStatusCode.Unauthorized;
        public override string Message { get; }
    }
}
