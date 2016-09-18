
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

            //Scheduler scheduler = new Scheduler();
            //scheduler.Start();
            //Thread.Sleep(240000);
            ////scheduler.Stop();

            //RunInteractive(ServicesToRun);

            //logger.Trace("trace message");
            //logger.Debug("debug message");
            //logger.Info("info message");
            //logger.Warn("warn message");
            //logger.Error("error message");
            //logger.Fatal("fatal message");
            //logger.Log(LogLevel.Info, "log message");
        }
    }
}
