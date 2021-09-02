using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJournalsRepository Journals { get; }
        ILoginRepository Login { get; }
        IResearcherRepository Researchers { get; }
        ISubscriberRepository Subscribers { get; }

        int Complete();


    }
}
