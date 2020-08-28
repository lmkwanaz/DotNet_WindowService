
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Entity;
using University.Repository;

namespace University.Domain
{
    public class UniversityDomain : IUniversityDomain
    {
        IUniversityRepository _repository;

        public UniversityDomain(IUniversityRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(Student Username)
        {
            _repository.AddUser(Username);
        }

        public void AddUser()
        {
            Student student = new Student() {
             Username = "Neo",
             Password = "Password@1",
             Active = true
            };
            AddUser(student);
        }

        public void DeleteUser(int UserID)
        {
            _repository.DeleteUser(UserID);
        }

        public List<Student> GetUser(int? UserID, string Username = null)
        {
            return _repository.GetUser(UserID, Username);
        }

        public void UpdateUser(Student Username)
        {
            _repository.UpdateUser(Username);
        }
    }
}
