using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPerformance.Models
{
    public class ScrumMasterDetail
    {
        [Display(Name="Scrum Master Id")]
        public int ScrumMasterId { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        public string  LastName { get; set; }
    }
}
