using ICM.JHB.Utility.NHibernate;
using log4net;
using Ninject.Core;
using Ninject.Core.Behavior;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data;
using University.Domain;
using University.Repository;

namespace University.WindowsServices.Ioc
{
    class UniversityModule : StandardModule
    {
        private readonly ILog _logger;
        public UniversityModule()
        {
            try
            {
              
                log4net.Config.XmlConfigurator.Configure();
                _logger = LogManager.GetLogger("UniversityWindowsService");
                _logger.Debug("UniversityWindowsService starting...");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("UniversityWindowsService", string.Format("Failed to initialize module. {0}", ex.ToString()), EventLogEntryType.Error);
            }
        }
        public override void Load()
        {
            //Bind<NSessionService>().To<UniversitySession>().Using<SingletonBehavior>();
            Bind<UniversitySession>().ToSelf().Using<SingletonBehavior>();
            Bind<IUniversityRepository>().To<UniversityRepository>();
            Bind<IUniversityDomain>().To<UniversityDomain>();
            Bind<ILog>().ToConstant(_logger); new NotImplementedException();
        }
    }
}
