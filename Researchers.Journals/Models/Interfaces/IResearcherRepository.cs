using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Interfaces
{
    public interface IResearcherRepository : IGenericRepository<Researcher>
    {
        Task<List<Researcher>> GetResearcher();

        Task<Researcher> GetResearcherByResearcherName(string researcherName);

        Task<Researcher> AddResearcher(Researcher researcher);

        Task<Researcher> UpdateResearcherDetails(Researcher researcher);

        bool DeleteResearcher(Researcher researcher);

        Task<Researcher> GetResearcherByResearcherID(int researcherID);

    }
}
