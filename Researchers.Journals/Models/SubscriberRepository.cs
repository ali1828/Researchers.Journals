using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class SubscriberRepository : ISubscriberRepository
    {
        public void Add(Subscribers entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Subscribers> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscribers>> CreateSubscribedJournals(List<Subscribers> subscribers)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubscribedJournalByJournalID(int journalID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubscribedJournals(List<Subscribers> subscribers)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscribers> Find(Expression<Func<Subscribers, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscribers> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscribers>> GetAllSubscribers()
        {
            throw new NotImplementedException();
        }

        public Subscribers GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscribers> GetSubscribedJournalByJournalId(int journalId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscribers>> GetSubscribedResearchersById(int subscribedResearcherId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Subscribers entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Subscribers> entities)
        {
            throw new NotImplementedException();
        }
    }
}
