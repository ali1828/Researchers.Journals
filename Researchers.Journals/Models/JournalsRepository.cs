using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class JournalsRepository : IJournalsRepository
    {

        private readonly ResearcherJournalDbContext _Context;
        public JournalsRepository(ResearcherJournalDbContext context) : base()
        {
            _Context = context;
        }

        public async Task<Journals> CreateJournal(Journals journal)
        {
            try
            {
                _Context.Add(journal);
                _Context.SaveChanges();
                return journal;
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

        public bool DeleteJournal(Journals journal)
        {
            try
            {
                _Context.Remove(journal);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public async Task<Journals> GetJournalByJournalID(int journalID)
        {
            var result = _Context.Journals.Where(p => p.JournalID == journalID).FirstOrDefault();
            if(result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Journals>> GetJournals()
        {
            return _Context.Journals.ToList();
        }

        public async Task<Journals> GetJournalsByJournalName(string journalName)
        {
            var result = _Context.Journals.Where(p => p.JournalName == journalName).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Journals>> GetJournalsByResearcherID(int researcherID)
        {
            var result = _Context.Journals.Where(p => p.ResearcherID == researcherID).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Journals> UpdateJournalDetails(Journals journal)
        {
            _Context.Journals.Update(journal);
            _Context.SaveChanges();
            return journal;
        }
    }
}
