
using System.ServiceProcess;
using NLog;
using System.Threading;

namespace EmailScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static Logger logger = LogManager.GetCurrentClassLogger();


        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Scheduler()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
