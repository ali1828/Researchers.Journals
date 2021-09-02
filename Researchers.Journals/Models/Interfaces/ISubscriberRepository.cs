using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Interfaces
{
    public interface ISubscriberRepository 
    {
        Task<List<Subscribers>> GetAllSubscribers();

        Task<List<Subscribers>> GetSubscribedResearchersById(int subscribedResearcherId);

        Task<Subscribers> GetSubscribedJournalByJournalId(int journalId);

        Task<List<Subscribers>> CreateSubscribedJournals(List<Subscribers> subscribers);

        bool DeleteSubscribedJournals(List<Subscribers> subscribers);

        bool DeleteSubscribedJournalByJournalID(int journalID);
       
    }
}
