using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public static class ExceptionHandler
    {

       public static string ToLongString(this Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Exception**************");
            builder.AppendLine(ex.Source);
            builder.AppendLine(ex.Message);
            builder.AppendLine(ex.StackTrace);
            AppendInnerExceptionsRecursive(ex.InnerException, builder);
            return builder.ToString();
        }

        private static void AppendInnerExceptionsRecursive (Exception innerException, StringBuilder builder)
        {
            if (innerException != null)
            {
                builder.AppendLine("Inner Exception**************");
                builder.AppendLine(innerException.Source);
                builder.AppendLine(innerException.Message);
                builder.AppendLine(innerException.StackTrace);

                AppendInnerExceptionsRecursive(innerException.InnerException, builder);
            }
        }

    }
}
