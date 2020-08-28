using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Entity;

namespace University.Domain
{
   public interface IUniversityDomain
    {
        List<Student> GetUser(int? UserID, string Username = null);
        void AddUser();
        void AddUser(Student Username);
        void UpdateUser(Student Username);
        void DeleteUser(int UserID);
    }
}
