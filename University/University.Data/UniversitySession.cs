using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ICM.JHB.Utility.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Entity;

namespace University.Data
{
    public class UniversitySession : NSessionService
    {
        protected override void SetSession()
        {
           
            if (_factory == null)
            {
                _factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("UniversityWS")))
                    .Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssemblyOf<Student>();
                    })
                    .BuildSessionFactory();
            }
        }
    }
}
