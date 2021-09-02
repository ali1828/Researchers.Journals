using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Researchers.Journals.ViewModel
{
    public class UploadJournalVM 
    {
        public Researchers.Journals.Models.Journals Journal { get; set; }
        public IFormFile File { get; set; }
      
    }
}
