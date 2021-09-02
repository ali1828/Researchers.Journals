using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models
{
    public class Subscribers
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "JournalID can't be empty")]
        public int JournalID { get; set; }

        [Required(ErrorMessage = "ResearcherID can't be empty")]
        public int ResearcherID { get; set; }

        [Required(ErrorMessage = "SubscriberAsAResearcher ID can't be empty")]
        public int SubscriberAsResearcherID { get; set; }
    }
}
