using ICM.JHB.Utility.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.WindowsServices.Ioc;

namespace University.WindowsServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if(args.Length == 1 && "/console".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
            {

                Start();
                Console.WriteLine("Service started. Ctrl-C to terminate.");
                using (var e = new ManualResetEvent(false))
                {
                    e.WaitOne();
                }
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                            new UniversityService()
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void Start()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //logger = LogManager.GetLogger("CIS Event Store");
            Ninject_IOC.Container.Load(new Ninject.Core.IModule[] { new UniversityModule() });
            //created a method so it can call the method to add A user.
            Ninject_IOC.Container.Get<UniversityDomain>().AddUser();

        }
    }
}
