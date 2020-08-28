using log4net;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Data;
using University.Data.Entity;

namespace University.Repository
{
    public class UniversityRepository : IUniversityRepository
    {

        private readonly UniversitySession _nhibernateSession;
        private static ILog _logger;

        public UniversityRepository(ILog logger, UniversitySession nhibernateSession)
        {
            _logger = logger;
            _nhibernateSession = nhibernateSession;
        }

        public void AddUser(Student Username)
        {
            _logger.Debug("Executing AddUser");
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    if (Username.Username != null && !Username.Username.Equals(""))
                    {
                        session.Save(Username);
                        session.Flush();
                    }
                    else
                    {
                        throw new Exception(string.Format("Cannot save user without a valid username"));
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.Error("Error on AddUser", ex);
                throw ex;
            }
        }

        public void DeleteUser(int UserID)
        {
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    var user = session.Query<Student>().SingleOrDefault(p => p.UserID == UserID);

                    if (user == null)
                        throw new Exception(string.Format("Artist with ID {0} is not found", UserID));

                    session.Delete(user);
                    session.Flush();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error on Delete", ex);
                throw ex;
            }
        }

        public List<Student> GetUser(int? UserID, string Username = null)
        {
            using (var session = _nhibernateSession.CreateSession())
            {
                try
                {
                    var query = session.QueryOver<Student>();

                    if (UserID != null)
                        query.Where(p => p.UserID == UserID);
                    if (Username != null)
                        query.And(p => p.Username == Username);


                    return query.List<Student>()
                        .ToList();


                }
                catch (Exception ex)
                {
                    _logger.Error("Error on GetUsers", ex);
                    throw ex;
                }
            }
        }

        public void UpdateUser(Student Username)
        {
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    if (Username.UserID == 0)
                        throw new Exception("ID must have a value");

                    session.SaveOrUpdate(Username);
                    session.Flush();
                }
            }
            catch (Exception ex)
            {

                _logger.Error("Error on UpdateArtist", ex);
                throw ex;
            }
        }
    }
}
