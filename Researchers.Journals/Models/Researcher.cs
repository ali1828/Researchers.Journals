using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models
{
    public class Researcher
    {
        [Key]
        [Range(0000000, 9999999)]
        public int ResearcherID { get; set; }


        [MaxLength(200)]
        [Display(Name = "Researcher Name")]
        [Required(ErrorMessage = "Researcher Name is Required", AllowEmptyStrings = false)]
        public string ResearcherName { get; set; }


        #region "Navigation Properties"

        public List<Journals> Journals { get; set; }

        #endregion
    }
}
