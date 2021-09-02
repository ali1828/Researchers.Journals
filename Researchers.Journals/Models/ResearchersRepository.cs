using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class ResearchersRepository : IResearcherRepository
    {
        private readonly ResearcherJournalDbContext _Context;
        public ResearchersRepository(ResearcherJournalDbContext context) : base()
        {
            _Context = context;
        }

        public async Task<Researcher> AddResearcher(Researcher researcher)
        {
            _Context.Add(researcher);
            _Context.SaveChanges();
            return researcher;
        }

        public bool DeleteResearcher(Researcher researcher)
        {
            _Context.Remove(researcher);
            _Context.SaveChanges();
            return true;
        }

        public async Task<List<Researcher>> GetResearcher()
        {
            var researcherResult = _Context.Researchers.ToList();
            return researcherResult;
        }

        public async Task<Researcher> GetResearcherByResearcherID(int researcherID)
        {
            var result = _Context.Researchers.Where(p => p.ResearcherID == researcherID).FirstOrDefault();
            return result;
        }

        public async Task<Researcher> GetResearcherByResearcherName(string researcherName)
        {
            var result = _Context.Researchers.Where(p => p.ResearcherName == researcherName).FirstOrDefault();
            return result;
        }

        public async Task<Researcher> UpdateResearcherDetails(Researcher researcher)
        {
            _Context.Update(researcher);
            _Context.SaveChanges();
            return researcher;
        }
    }
}
