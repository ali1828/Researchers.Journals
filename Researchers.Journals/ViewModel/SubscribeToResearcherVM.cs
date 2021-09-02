using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.ViewModel
{
    public class SubscribeToResearcherVM
    {
        public List<Researchers.Journals.Models.Researcher> ResearchersToSubscribed { get; set; } = new List<Models.Researcher>();
    }
}
