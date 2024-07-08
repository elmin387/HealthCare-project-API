using HealthCare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Common
{
        public static class ExceptionHandler
        {
            public static void HandleExceptionResponse(Exception ex, BaseGridResponse response)
            {
                HandleException(ex, response);
            }

            public static void HandleExceptionResponse(Exception ex, BaseResponse response)
            {
                HandleException(ex, response);
            }

            public static void HandleFailedMessage(BaseResponse response, string message)
            {
                response.Success = false;
                response.Errors.Add(message);
            }

            private static void HandleException(Exception ex, BaseResponse response)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
        }
}
