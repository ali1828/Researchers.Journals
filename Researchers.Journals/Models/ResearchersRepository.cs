using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Researchers.Journals.Models.Interfaces;

namespace Researchers.Journals.Models
{
    public class ResearchersRepository : IResearcherRepository
    {
        public void Add(Researcher entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Researcher> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Researcher> AddResearcher(Researcher researcher)
        {
            throw new NotImplementedException();
        }

        public bool DeleteResearcher(Researcher researcher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Researcher> Find(Expression<Func<Researcher, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Researcher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Researcher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Researcher>> GetResearcher()
        {
            throw new NotImplementedException();
        }

        public Task<Researcher> GetResearcherByResearcherID(int researcherID)
        {
            throw new NotImplementedException();
        }

        public Task<Researcher> GetResearcherByResearcherName(string researcherName)
        {
            throw new NotImplementedException();
        }

        public void Remove(Researcher entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Researcher> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Researcher> UpdateResearcherDetails(Researcher researcher)
        {
            throw new NotImplementedException();
        }
    }
}
