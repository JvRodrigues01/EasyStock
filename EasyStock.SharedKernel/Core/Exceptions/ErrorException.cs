using EasyStock.SharedKernel.Core.Contracts;
using System.Net;

namespace EasyStock.SharedKernel.Core.Exceptions
{
    public class ErrorException : Exception, IException
    {
        public int Code { get; set; } = (int)HttpStatusCode.InternalServerError;
        public override string Message { get; }
    }
}
