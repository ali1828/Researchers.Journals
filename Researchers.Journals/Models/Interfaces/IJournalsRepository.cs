using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models.Interfaces
{
    public interface IJournalsRepository 
    {
        Task<List<Journals>> GetJournalsByResearcherID(int researcherID);

        Task<List<Journals>> GetJournals();

        Task<Journals> GetJournalsByJournalName(string journalName);

        Task<Journals> CreateJournal(Journals journal);

        Task<Journals> UpdateJournalDetails(Journals journal);

        bool DeleteJournal(Journals journal);

        Task<Journals> GetJournalByJournalID(int journalID);

    }
}
