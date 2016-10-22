using System;
using System.Text;
using NLog;

namespace CommonLogger
{
    public static class ExceptionHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo (string info)
        {
            logger.Info(info);
        }

        public static string LogException(this Exception ex)
        {
            logger.Info("logger info");
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Exception**************");
            builder.AppendLine(ex.Source);
            builder.AppendLine(ex.Message);
            builder.AppendLine(ex.StackTrace);
            AppendInnerExceptionsRecursive(ex.InnerException, builder);
            return builder.ToString();
        }

        private static void AppendInnerExceptionsRecursive(Exception innerException, StringBuilder builder)
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
