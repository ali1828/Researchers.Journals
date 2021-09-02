using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models
{
    public class Journals
    {
        [Key]
        public int JournalID { get; set; }

        [Display(Name ="Journal Name")]
        [Required(ErrorMessage = "Journal Name is Required", AllowEmptyStrings = false)]
        public string JournalName { get; set; }

        [Display(Name = "Journal Pdf")]
        [Required(ErrorMessage = "Upload Journal PDF", AllowEmptyStrings = false)]
        public byte[] JournalDocument { get; set; }

        [Display(Name = "Upload Date")]
        public DateTime UploadedDate { get; set; }


        #region "Navigation Properties"

        public int ResearcherID { get; set; }
        public Researcher Researcher { get; set; }

        #endregion

    }
}
