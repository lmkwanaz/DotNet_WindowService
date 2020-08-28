using ICM.JHB.Utility.Ninject;
using log4net;
using Ninject.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using University.Domain;
using University.WindowsServices.Ioc;

namespace University.WindowsServices
{
    public partial class UniversityService : ServiceBase
    {
        private readonly ILog _logger;
        private IUniversityDomain _domain;
        private System.Timers.Timer timerDelay;
        public UniversityService()
        {
            InitializeComponent();
            Ninject_IOC.Container.Load(new IModule[] { new UniversityModule() });
            _logger = Ninject_IOC.Container.Get<ILog>();
            _domain = Ninject_IOC.Container.Get<IUniversityDomain>();

            timerDelay = new System.Timers.Timer(double.Parse(ConfigurationManager.AppSettings["ServiceTimerInterval"]));
            timerDelay.Elapsed += new ElapsedEventHandler(TimerDelay_Elapsed);
        }

        private void TimerDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Debug("Timer Elapsed...");
            _domain.AddUser();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _logger.Info("Integration Service Started");
                timerDelay.Enabled = true;
            }
            catch (Exception e)
            {
                Ninject_IOC.Container.Dispose();
                _logger.Error(e.Message, e);
            }
        }

        protected override void OnStop()
        {
            _logger.Info("Integration Service Stopped");
            timerDelay.Enabled = false;
        }
    }
}
