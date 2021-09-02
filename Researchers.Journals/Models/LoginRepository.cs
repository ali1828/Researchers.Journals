using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class LoginRepository : ILoginRepository
    {
        public void Add(Login entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Login> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Login> CreateLogin(Login login)
        {
            throw new NotImplementedException();
        }

        public void DeleteLogin(Login login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Login> Find(Expression<Func<Login, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Login> GetAll()
        {
            throw new NotImplementedException();
        }

        public Login GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginDetails(int loginId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Login entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Login> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Login> UpdateLoginDetails(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
