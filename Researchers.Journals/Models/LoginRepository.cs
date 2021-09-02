using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ResearcherJournalDbContext _Context;
        public LoginRepository(ResearcherJournalDbContext context) : base()
        {
            _Context = context;
        }

        public async Task<Login> CreateLogin(Login login)
        {
            _Context.Add(login);
            _Context.SaveChanges();
            return login;
        }

        public void DeleteLogin(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Login> GetLoginDetails(Login login)
        {
            var loginResult = _Context.Logins.Where(p => p.Password == login.Password && 
                             p.Email == login.Email).FirstOrDefault();
            if (login != null)
            {
                return login;
            }
            return null;
        }

        public Task<Login> UpdateLoginDetails(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
