using FluentNHibernate.Mapping;
using University.Data.Entity;

namespace University.Data.Map
{
    class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(p => p.UserID);
            Map(p => p.Username);
            Map(p => p.Password);
            Map(p => p.Active);
        }
    }
}
