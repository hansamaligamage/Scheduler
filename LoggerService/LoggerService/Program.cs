using NLog;

namespace LoggerService
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Hello World!");
        }
    }
}
