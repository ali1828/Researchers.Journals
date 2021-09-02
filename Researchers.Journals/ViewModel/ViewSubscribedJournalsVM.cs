using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.ViewModel
{
    public class ViewSubscribedJournalsVM
    {
        public List<Researchers.Journals.Models.Journals> SubscribedJournals 
            { get; set; } = new List<Models.Journals>();
    }
}
