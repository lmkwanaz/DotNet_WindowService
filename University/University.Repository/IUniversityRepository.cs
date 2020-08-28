using University.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Repository
{
   public interface IUniversityRepository
    {
        List<Student> GetUser(int? UserID, string Username = null);
        void AddUser(Student Username);
        void UpdateUser(Student Username);
        void DeleteUser(int UserID);
    }
}
