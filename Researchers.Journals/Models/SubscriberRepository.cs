using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ResearcherJournalDbContext _Context;
        public SubscriberRepository(ResearcherJournalDbContext context) : base()
        {
            _Context = context;
        }

        public async Task<List<Subscribers>> CreateSubscribedJournals(List<Subscribers> subscribers)
        {
            _Context.AddRange(subscribers);
            _Context.SaveChanges();
            return subscribers;
        }

        public bool DeleteSubscribedJournalByJournalID(int journalID)
        {
            var result = _Context.Subscribers.Where(p => p.JournalID == journalID).FirstOrDefault();
            _Context.Subscribers.Remove(result);
            _Context.SaveChanges();
            return true;
        }

        public bool DeleteSubscribedJournals(List<Subscribers> subscribers)
        {
            _Context.Subscribers.RemoveRange(subscribers);
            _Context.SaveChanges();
            return true;
        }

        public async Task<List<Subscribers>> GetAllSubscribers()
        {
            var result = _Context.Subscribers.ToList();
            return result;
        }

        public async Task<Subscribers> GetSubscribedJournalByJournalId(int journalId)
        {
            var result = _Context.Subscribers.Where(p => p.JournalID == journalId).FirstOrDefault();
            return result;
        }

        public async Task<List<Subscribers>> GetSubscribedResearchersById(int subscribedResearcherId)
        {
            var result = _Context.Subscribers.Where(p => p.SubscriberAsResearcherID 
                                        == subscribedResearcherId).ToList();
            return result;
        }
    }
}
