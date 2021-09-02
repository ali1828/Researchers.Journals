using Researchers.Journals.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public IJournalsRepository Journals => throw new NotImplementedException();

        public ILoginRepository Login => throw new NotImplementedException();

        public IResearcherRepository Researchers => throw new NotImplementedException();

        public ISubscriberRepository Subscribers => throw new NotImplementedException();

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
