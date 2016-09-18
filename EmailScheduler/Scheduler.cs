using System.ServiceProcess;
using System.Timers;
using NLog;
using EmailApp;
using System.Collections.Generic;
using EmailService.Viewmodel;
using System;
using CommonLogger;
using System.Diagnostics;

namespace EmailScheduler
{
    public partial class Scheduler : ServiceBase
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Debugger.Launch();
            logger.Info("Service is started.");
            try
            {
                Timer tmrEmailScheduler = new Timer();
                tmrEmailScheduler.Interval = 120000;
                tmrEmailScheduler.Elapsed += tmrEmailScheduler_Elapsed;
                tmrEmailScheduler.Start();
                ProcessEmail.CreateEmail();
            }
            catch (Exception ex)
            {
                logger.Error(ExceptionHandler.LogException(ex));
            }
        }

        protected override void OnStop()
        {
            logger.Info("Service is stopped.");
            tmrEmailScheduler.Stop();
        }

        private void tmrEmailScheduler_Elapsed(object sender, ElapsedEventArgs e)
        {
            logger.Info("Timer is ticked");
            ProcessEmail.CreateEmail();
        }


        public void Start()
        {
            //ProcessEmail.CreateEmail();
            Timer tmrEmailScheduler = new Timer();
            tmrEmailScheduler.Interval = 120000;
            tmrEmailScheduler.Elapsed += tmrEmailScheduler_Elapsed;
            tmrEmailScheduler.Start();
            ProcessEmail.CreateEmail();
        }

        //public void Stop ()
        //{
        //    tmrEmailScheduler.Stop();
        //}

    }
}
