using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class JournalsRepository : IJournalsRepository
    {
        public void Add(Journals entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Journals> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Journals> CreateJournal(Journals journal)
        {
            throw new NotImplementedException();
        }

        public bool DeleteJournal(Journals journal)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Journals> Find(Expression<Func<Journals, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Journals> GetAll()
        {
            throw new NotImplementedException();
        }

        public Journals GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Journals> GetJournalByResearcherID(int researcherID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Journals>> GetJournals()
        {
            throw new NotImplementedException();
        }

        public Task<Journals> GetJournalsByJournalName(string journalName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Journals>> GetJournalsByResearcherID(int researcherID)
        {
            throw new NotImplementedException();
        }

        public void Remove(Journals entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Journals> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Journals> UpdateJournalDetails(Journals journal)
        {
            throw new NotImplementedException();
        }
    }
}
