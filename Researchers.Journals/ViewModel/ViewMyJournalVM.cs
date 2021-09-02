using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Researchers.Journals.Models;

namespace Researchers.Journals.ViewModel
{
    public class ViewMyJournalVM
    {
        public List<Researchers.Journals.Models.Journals> MyJournals
            { get; set; } = new List<Models.Journals>();
    }
}
