using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Interfaces
{
    public interface ILoginRepository 
    {
        Task<Login> CreateLogin(Login login);

        void DeleteLogin(Login login);

        Task<Login> UpdateLoginDetails(Login login);

        Task<Login> GetLoginDetails(Login login);

        Task<Login> GetLoginByEmail(string email);

    }
}
